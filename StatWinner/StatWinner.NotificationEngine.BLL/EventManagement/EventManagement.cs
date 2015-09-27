using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatWinner.Common.Responses;
using StatWinner.NotificationEngine.BLL.Common;
using StatWinner.NotificationEngine.BLL.Common.EventManagement.Entities;

namespace StatWinner.NotificationEngine.BLL.EventManagement
{
    public class EventManagement : IEventManagement
    {
       public EventManagement()
        {
            //This is gonna be replaced with depenedency injection in future
            //_manager = new MongoEventManagement();
        }

        public ListResponse<EventCategory> ListEventCategories()
        {
            var manager =
                StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IEventManagement>();

            return manager.ListEventCategories();
        }

        public BooleanResponse SaveEventCategories(List<EventCategory> eventCategories)
        {
            var manager =
                StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IEventManagement>();
            return manager.SaveEventCategories(eventCategories);
        }

        public ListResponse<EventEntity> LoadNotificationEvents()
        {
            var manager =
                StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IEventManagement>();
            return manager.LoadNotificationEvents();
        }

        public async Task<BooleanResponse> SaveNotificationEvent(EventEntity entity)
        {
            var manager =
                StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IEventManagement>();
            return await manager.SaveNotificationEvent(entity);
        }
    }
}
