using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatWinner.AccountManagement.BLL.Common.UserAccount.Entities;
using StatWinner.AccountManagement.BLL.Common.UserAccount.Requests;
using StatWinner.Common.Responses;

namespace StatWinner.AccountManagement.BLL.Common.UserAccount
{
    public interface IUserAccountManagement
    {
        /// <summary>
        /// Checks if the email is valid or already in use
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        IsValidEmailResponse IsValildEmail(string emailAddress, string Id);

        /// <summary>
        /// Loads the list of all countries
        /// </summary>
        /// <returns></returns>
        ListResponse<Country> LoadAllCountries();

        /// <summary>
        /// Registers user in the system
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<BooleanResponse> UserRegistration(RegisterUser user);

        /// <summary>
        /// Signs user in the system
        /// </summary>
        /// <param name="signInUser"></param>
        /// <returns></returns>
        Task<BooleanResponse> SignInUser(SignInRequest signInUser);
    }
}
