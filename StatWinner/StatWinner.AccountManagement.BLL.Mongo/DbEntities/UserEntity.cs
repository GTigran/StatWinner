using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace StatWinner.AccountManagement.BLL.Mongo.DbEntities
{
    public class UserEntity
    {
        [BsonId]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
