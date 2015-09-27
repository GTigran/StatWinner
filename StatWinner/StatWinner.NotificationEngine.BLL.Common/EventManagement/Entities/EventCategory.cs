using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatWinner.NotificationEngine.BLL.Common.EventManagement.Entities
{
    public class EventCategory
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}