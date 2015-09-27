using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatWinner.NotificationEngine.BLL.Common.EventManagement.Entities
{
    /// <summary>
    /// Event User Entity
    /// </summary>
    public class EventUserEntity
    {
        public string UserId { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
    }
}
