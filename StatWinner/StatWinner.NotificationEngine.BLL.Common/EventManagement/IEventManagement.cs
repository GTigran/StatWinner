using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StatWinner.Common.Responses;
using StatWinner.NotificationEngine.BLL.Common.EventManagement.Entities;

namespace StatWinner.NotificationEngine.BLL.Common
{
    public interface IEventManagement
    {
        /// <summary>
        /// List all event categories
        /// </summary>
        /// <returns></returns>
        ListResponse<EventCategory> ListEventCategories();

        /// <summary>
        /// Saves event categories
        /// </summary>
        /// <param name="eventCategories"></param>
        /// <returns></returns>
        BooleanResponse SaveEventCategories(List<EventCategory> eventCategories);

        /// <summary>
        /// Loads the list of notification events
        /// </summary>
        /// <returns></returns>
        ListResponse<EventEntity> LoadNotificationEvents();

        /// <summary>
        /// Save Notification Event
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<BooleanResponse> SaveNotificationEvent(EventEntity entity);
    }
}
