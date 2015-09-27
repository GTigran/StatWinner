using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AspNet.Identity.MongoDB.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MongoDB.Driver;
using StatWinner.AccountManagement.BLL.Common.UserAccount;
using StatWinner.AccountManagement.BLL.Common.UserAccount.Entities;
using StatWinner.AccountManagement.BLL.Common.UserAccount.Requests;
using StatWinner.AccountManagement.BLL.Mongo.DbEntities;
using StatWinner.AccountManagement.BLL.Mongo.Factory;
using StatWinner.Common;
using StatWinner.Common.Responses;
using StatWinner.CommonExtensions;

namespace StatWinner.AccountManagement.BLL.Mongo
{
    public class MongoUserAccountManagement : IUserAccountManagement
    {
        public MongoUserAccountManagement()
        {
            this.MongoDbClient = new MongoClient(StatWinnerConfigurationManager.MongoDBConnectionString);
            this.StatWinnerDatabase = this.MongoDbClient.GetDatabase(StatWinnerConfigurationManager.StatWinnerDB);
            this.IdentityDatabase = this.MongoDbClient.GetDatabase(StatWinnerConfigurationManager.IdentityDB);
        }

        #region "Properties"


        private MongoClient MongoDbClient { get; set; }

        private IMongoDatabase StatWinnerDatabase { get; set; }

        private IMongoDatabase IdentityDatabase { get; set; }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private IAuthenticationManager AuthManager
        {
            get { return HttpContext.Current.Request.GetOwinContext().Authentication; }
        }

        #endregion

        #region Methods

        public IsValidEmailResponse IsValildEmail(string emailAddress, string Id)
        {
            var mongoCollection = this.IdentityDatabase.GetCollection<UserEntity>("users");

            var exists = true;
            try
            {
                exists =
                mongoCollection.Find(u => u.Email == emailAddress && (Id.IsNullOrEmpty() || !u.Id.Equals(Id)))
                    .CountAsync()
                    .Result > 0;
            }
            catch (Exception ex)
            {
            }

            return new IsValidEmailResponse()
            {
                isValid = !exists
            };
        }

        public ListResponse<Country> LoadAllCountries()
        {
            var response = new ListResponse<Country>();

            try
            {
                var mongoCollection = this.StatWinnerDatabase.GetCollection<CountryEntity>("Countries");
                var sortDefinition = new SortDefinitionBuilder<CountryEntity>();
                var lst =
                    mongoCollection.Find(_ => true)
                        .Sort(sortDefinition.Ascending("name"))
                        .ToListAsync()
                        .Result.Select(UserAccountManagementFactory.convertToCountry)
                        .ToList();
                response.Result = lst;
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }
            return response;
        }

        /// <summary>
        /// Registers user in the system
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        public async Task<BooleanResponse> UserRegistration(RegisterUser registerUser)
        {
            var response = new BooleanResponse();
            try
            {
                
                var user = new ApplicationUser()
                {
                    City = registerUser.City,
                    CountryId = registerUser.CountryId,
                    Email = registerUser.Email,
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,

                    State = registerUser.State,
                    UserName = registerUser.Email
                };

                var result = await UserManager.CreateAsync(user, registerUser.Password);

                if (result.Succeeded)
                {
                    user = UserManager.FindByName(registerUser.Email);
                    var identity = await user.GenerateUserIdentityAsync(UserManager);
                    AuthManager.SignIn(new AuthenticationProperties {IsPersistent = true}, identity);
                    response.Result = true;
                }
                else
                {
                    response.Errors.AddRange(result.Errors.Select(s => new Error() { Message = s}));
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        /// <summary>
        /// Signs user in the system
        /// </summary>
        /// <param name="signInUser"></param>
        /// <returns></returns>
        public async Task<BooleanResponse> SignInUser(SignInRequest signInUser)
        {
            var response = new BooleanResponse();
            
            try
            {

                const string errorMessage = "Invalid Email or Password";

                var user = await UserManager.FindByNameAsync(signInUser.Email);
                if (user == null)
                {
                    response.SetError(errorMessage);
                }

                var isValidUser = await UserManager.CheckPasswordAsync(user, signInUser.Password);

                if (isValidUser)
                {
                    AuthManager.SignOut();
                    var identity = await user.GenerateUserIdentityAsync(UserManager);

                    if (signInUser.RememberMe)
                    {
                        var rememberBrowserIdentity = AuthManager.CreateTwoFactorRememberBrowserIdentity(user.Id);
                        AuthManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity, rememberBrowserIdentity);
                    }
                    else
                    {
                        AuthManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
                    }

                    response.Result = true;
                }
                else
                {
                    response.SetError("");
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        #endregion
    }
}
