using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StatWinner.AccountManagement.BLL.Common.UserAccount.Entities;
using StatWinner.AccountManagement.BLL.Mongo.DbEntities;

namespace StatWinner.AccountManagement.BLL.Mongo.Factory
{
    public static class UserAccountManagementFactory
    {

        public static Func<CountryEntity, Country> convertToCountry = delegate(CountryEntity entity)
        {
            AutoMapper.Mapper.CreateMap<CountryEntity, Country>().ForMember(a => a.Id, b => b.MapFrom(src => src.Id.ToString()));
            return AutoMapper.Mapper.Map<Country>(entity);
        };
    }
}
