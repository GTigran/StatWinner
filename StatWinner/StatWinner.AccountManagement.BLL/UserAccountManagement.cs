using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatWinner.AccountManagement.BLL.Common.UserAccount;
using StatWinner.AccountManagement.BLL.Common.UserAccount.Entities;
using StatWinner.AccountManagement.BLL.Common.UserAccount.Requests;
using StatWinner.Common.Responses;

namespace StatWinner.AccountManagement.BLL
{
    public class UserAccountManagement : IUserAccountManagement
    {
        public IsValidEmailResponse IsValildEmail(string emailAddress, string Id)
        {
            var manager =
                StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IUserAccountManagement>();
            return manager.IsValildEmail(emailAddress, Id);
        }

        public ListResponse<Country> LoadAllCountries()
        {
            var manager =
                StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IUserAccountManagement>();
            return manager.LoadAllCountries();
        }

        public async Task<BooleanResponse> UserRegistration(RegisterUser user)
        {
            var manager =
                StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IUserAccountManagement>();
            return await manager.UserRegistration(user);
        }

        /// <summary>
        /// Signs user in the system
        /// </summary>
        /// <param name="signInUser"></param>
        /// <returns></returns>
        public async Task<BooleanResponse> SignInUser(SignInRequest signInUser)
        {
            var manager =
                StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IUserAccountManagement>();
            return await manager.SignInUser(signInUser);
        }

    }
}
