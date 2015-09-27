using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StatWinner.Configuration.Interfaces;

namespace StatWinner.Configuration.MongoDBProvider
{
    public class MongoConfigurationSetting : IConfigurationSetting
    {
        public MongoConfigurationSetting()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        public string Id { get; set; }
        public string FieldName { get; set; }
        public object FieldValue { get; set; }
        [BsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
