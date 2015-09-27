using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StatWinner.AccountManagement.BLL.Mongo.DbEntities
{
    /// <summary>
    /// Country Entity
    /// </summary>
    public class CountryEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("iso")]
        public string ISO { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("niceName")]
        public string NiceName { get; set; }
        [BsonElement("iso3")]
        public string Iso3 { get; set; }
        [BsonElement("numcode")]
        public string NumCode { get; set; }
        [BsonElement("phonecode")]
        public string PhoneCode { get; set; }
        [BsonElement("sortIndex")]
        public int? SortIndex { get; set; }

    }
}
