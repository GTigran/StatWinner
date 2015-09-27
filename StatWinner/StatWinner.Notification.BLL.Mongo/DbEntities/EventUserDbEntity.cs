using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatWinner.Notification.BLL.Mongo.DbEntities
{
    public class EventUserDbEntity
    {
        public string UserId { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
    }
}
