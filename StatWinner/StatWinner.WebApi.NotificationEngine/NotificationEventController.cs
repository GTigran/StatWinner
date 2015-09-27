using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using StatWinner.Common.Responses;
using StatWinner.NotificationEngine.BLL.Common.EventManagement.Entities;
using StatWinner.NotificationEngine.BLL.EventManagement;

namespace StatWinner.WebApi.NotificationEngine
{
    [RoutePrefix("api/NotificationEvent")]
    public class NotificationEventController : ApiController
    {
        #region "Properties"

        #endregion "Properties"

        #region Methods

        [Route("ListEventCategories")]
        [HttpGet]
        public ListResponse<EventCategory> ListEventCategories()
        {
            var notificationEventManagement = new EventManagement();
            var response = notificationEventManagement.ListEventCategories();
            return response;
        }

        [Route("SaveEventCategories")]
        [HttpPost]
        public BooleanResponse SaveEventCategories(List<EventCategory> eventCategories)
        {
            var notificationEventManagement = new EventManagement();
            var response = notificationEventManagement.SaveEventCategories(eventCategories);
            return response;
        }

        /// <summary>
        /// Loads the list of notification events
        /// </summary>
        /// <returns></returns>
        [Route("LoadNotificationEvents")]
        [HttpGet]
        public ListResponse<EventEntity> LoadNotificationEvents()
        {
            var notificationEventManagement = new EventManagement();
            var response = notificationEventManagement.LoadNotificationEvents();
            return response;
        }

        /// <summary>
        /// Save Notification Event
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Route("SaveNotificationEvent")]
        [HttpPost]
        public async Task<BooleanResponse> SaveNotificationEvent(EventEntity entity)
        {
            var notificationEventManagement = new EventManagement();
            var response = await notificationEventManagement.SaveNotificationEvent(entity);
            return response;
        }



        #endregion
    }
}
