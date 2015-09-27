using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using StatWinner.Common;

namespace AspNet.Identity.MongoDB.Configuration
{
    public class ApplicationIdentityContext : IDisposable
    {

        public static ApplicationIdentityContext Create()
        {
            var client = new MongoClient(StatWinnerConfigurationManager.MongoDBConnectionString);
            var database = client.GetDatabase(StatWinnerConfigurationManager.IdentityDB);
            var users = database.GetCollection<ApplicationUser>("users");
            var roles = database.GetCollection<IdentityRole>("roles");
            return new ApplicationIdentityContext(users, roles);
        }

        private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users,
            IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<IdentityRole> Roles { get; set; }

        public IMongoCollection<ApplicationUser> Users { get; set; }

        public Task<List<IdentityRole>> AllRolesAsync()
        {
            return Roles.Find(r => true).ToListAsync();
        }

        public void Dispose()
        {
        }
    }
}
