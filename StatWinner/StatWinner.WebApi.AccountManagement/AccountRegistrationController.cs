using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using StatWinner.AccountManagement.BLL;
using StatWinner.AccountManagement.BLL.Common.UserAccount;
using StatWinner.AccountManagement.BLL.Common.UserAccount.Entities;
using StatWinner.AccountManagement.BLL.Common.UserAccount.Requests;
using StatWinner.Common.Responses;

namespace StatWinner.WebApi.AccountManagement
{
    [RoutePrefix("api/AccountRegistration")]
    public class AccountRegistrationController : ApiController
    {
        [Route("IsValidEmail")]
        [HttpGet]
        public IsValidEmailResponse IsValidEmail(string email, string userId = null)
        {
            var accountManagement = new UserAccountManagement();
            return accountManagement.IsValildEmail(email, userId);
        }

        [Route("LoadAllCountries")]
        [HttpGet]
        public ListResponse<Country> LoadAllCountries()
        {
            var accountManagement = new UserAccountManagement();
            var countries = accountManagement.LoadAllCountries();
            return countries;
        }

        /// <summary>
        /// Registers user
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserRegistration")]
        public async Task<BooleanResponse> UserRegistration(RegisterUser registerUser)
        {
            var accountManagement = new UserAccountManagement();
            var registerUserResult = await accountManagement.UserRegistration(registerUser);
            return registerUserResult;
        }


        /// <summary>
        /// Signs user in the system
        /// </summary>
        /// <param name="signInUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SignInUser")]
        public async Task<BooleanResponse> SignInUser(SignInRequest signInUser)
        {
            var accountManagement = new UserAccountManagement();
            var signInResult = await accountManagement.SignInUser(signInUser);
            return signInResult;
        }
    }
}
