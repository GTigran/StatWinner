using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AspNet.Identity.MongoDB.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MongoDB.Driver;
using StatWinner.Common;
using StatWinner.Common.Responses;
using StatWinner.Notification.BLL.Mongo.DbEntities;
using StatWinner.Notification.BLL.Mongo.Factory;
using StatWinner.NotificationEngine.BLL.Common;
using StatWinner.NotificationEngine.BLL.Common.EventManagement.Entities;
using MongoDB.Bson;
using StatWinner.CommonExtensions;

namespace StatWinner.Notification.BLL.Mongo
{
    public class MongoEventManagement : IEventManagement
    {
        #region "Properties"


        private MongoClient MongoDbClient { get; set; }

        private IMongoDatabase StatWinnerDatabase { get; set; }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        #endregion

        #region ctor

        public MongoEventManagement()
        {
            this.MongoDbClient = new MongoClient(StatWinnerConfigurationManager.MongoDBConnectionString);
            this.StatWinnerDatabase = this.MongoDbClient.GetDatabase(StatWinnerConfigurationManager.StatWinnerDB);
        }

        #endregion

        public ListResponse<EventCategory> ListEventCategories()
        {
            var response = new ListResponse<EventCategory>();

            try
            {
                var clnEventCategories = this.StatWinnerDatabase.GetCollection<EventCategoryDBEntity>("EventCategories");
                var sortDefinition = new SortDefinitionBuilder<EventCategoryDBEntity>();
                var lst = clnEventCategories.Find(_ => true)
                    .Sort(sortDefinition.Ascending(s => s.Name))
                    .ToListAsync()
                    .Result.Select(EventManagementFactory.ConvertToEventCategory)
                    .ToList();
                response.Result = lst;
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        public BooleanResponse SaveEventCategories(List<EventCategory> eventCategories)
        {
            var response = new BooleanResponse();

            try
            {
                var clnEventCategories = this.StatWinnerDatabase.GetCollection<EventCategoryDBEntity>("NotificationEventCategories");

                var existingList = clnEventCategories.Find(_ => true).ToListAsync().Result;
                var eventCategoriesToSave =
                    eventCategories.Select(EventManagementFactory.ConvertToEventCategoryEntity).ToList();

                var insertList = eventCategoriesToSave.Where(e => e.Id == ObjectId.Empty).ToList();
                insertList.ForEach(i => i.Id = ObjectId.GenerateNewId());

                var deleteList =
                    existingList.Where(l => eventCategories.All(ec => ec.Id != l.Id.ToString())).ToList();
                var deleteFilter = Builders<EventCategoryDBEntity>.Filter.In("_id", deleteList.Select(d => d.Id));
                var deleteResponse = clnEventCategories.DeleteManyAsync(deleteFilter);

                //Iterate over existing elemnts and replace
                foreach (
                    var setting in
                        eventCategoriesToSave.Where(cs => cs.Id != ObjectId.Empty)
                    )
                {
                    var updateFilter = Builders<EventCategoryDBEntity>.Filter.Eq("_id", setting.Id);
                    var replaceResponse = clnEventCategories.ReplaceOneAsync(updateFilter, setting);
                }

                var insertResponse = clnEventCategories.InsertManyAsync(insertList);

                return new BooleanResponse()
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        /// <summary>
        /// Loads the list of notification events
        /// </summary>
        /// <returns></returns>
        public ListResponse<EventEntity> LoadNotificationEvents()
        {
            var response = new ListResponse<EventEntity>();

            try
            {
                var clnEvents = this.StatWinnerDatabase.GetCollection<EventDbEntity>("NotificationEvents");
                var sortDefinition = new SortDefinitionBuilder<EventDbEntity>();
                var events =
                    clnEvents.Find(_ => true).Sort(sortDefinition.Ascending(r => r.EventKey)).ToListAsync().Result.Select(EventManagementFactory.ConvertToEvent).ToList();


                //Set Event Categories
                var clnEventCategories =
                    this.StatWinnerDatabase.GetCollection<EventCategoryDBEntity>("EventCategories");

                var evenTcategoriIds =
                    events.Where(e => !e.EventCategoryId.IsNullOrEmpty()).Select(e => ObjectId.Parse(e.EventCategoryId)).ToList();

                var eventCategoriesFilter = Builders<EventCategoryDBEntity>.Filter.In("_id", evenTcategoriIds);
                var eventCategories =
                    clnEventCategories.Find(eventCategoriesFilter).ToListAsync().Result.ToList();
                events.ForEach(ev => ev.EventCategoryName = (eventCategories.Single(ec => ec.Id.ToString() == ev.EventCategoryId).Name));

                response.Result = events;
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        /// <summary>
        /// Save Notification Event
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<BooleanResponse> SaveNotificationEvent(EventEntity entity)
        {
            var response = new BooleanResponse();

            try
            {
                var dbEntity = EventManagementFactory.ConvertToEventDbEntity(entity);

                ApplicationUser appUser = null;

                if (HttpContext.Current.User != null)
                {
                    appUser = await UserManager.FindByNameAsync(HttpContext.Current.User.Identity.Name);
                }

                if (dbEntity.Id == ObjectId.Empty)
                {
                    if (appUser != null)
                    {
                        dbEntity.CreatedBy = new EventUserDbEntity()
                        {
                            UserId = appUser.Id.ToString(),
                            EmailAddress = appUser.Email,
                            FullName = String.Format("{0} {1}", appUser.FirstName, appUser.LastName)
                        };
                    }

                    dbEntity.CreatedDate = DateTime.Now;
                }

                if (appUser != null)
                {
                    dbEntity.ModifiedBy = new EventUserDbEntity()
                    {
                        UserId = appUser.Id.ToString(),
                        EmailAddress = appUser.Email,
                        FullName = String.Format("{0} {1}", appUser.FirstName, appUser.LastName)
                    };
                }

                dbEntity.ModifiedDate = DateTime.Now;

                var clnEvents = this.StatWinnerDatabase.GetCollection<EventDbEntity>("NotificationEvents");
                if (dbEntity.Id == ObjectId.Empty)
                {
                    dbEntity.Id = ObjectId.GenerateNewId();
                    await clnEvents.InsertOneAsync(dbEntity);
                }
                else
                {
                    var updateFilter = Builders<EventDbEntity>.Filter.Eq("_id", dbEntity.Id);
                    await clnEvents.ReplaceOneAsync(updateFilter, dbEntity);
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

   
    }
}
