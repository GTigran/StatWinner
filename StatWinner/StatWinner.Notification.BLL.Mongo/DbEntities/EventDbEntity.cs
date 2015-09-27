using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace StatWinner.Notification.BLL.Mongo.DbEntities
{
    public class EventDbEntity
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Event Key
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// Event Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Is Html
        /// </summary>
        public bool IsHtml { get; set; }

        /// <summary>
        /// Default From
        /// </summary>
        public string DefaultFrom { get; set; }

        /// <summary>
        /// List of To Email Addresses
        /// </summary>
        public List<string> ToEmailAddresses { get; set; }

        /// <summary>
        /// Indicates whether to send email notification by default or not
        /// </summary>
        public bool SendEmailNotification { get; set; }

        /// <summary>
        /// Indicates whether to send system notification by default or not
        /// </summary>
        public bool SendSystemNotification { get; set; }

        /// <summary>
        /// Event Category ID
        /// </summary>
        public string EventCategoryId { get; set; }

        /// <summary>
        /// Is User Subscription Required
        /// </summary>
        public bool IsUserSubscriptionRequired { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Created by event user
        /// </summary>
        public EventUserDbEntity CreatedBy { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Created by event user
        /// </summary>
        public EventUserDbEntity ModifiedBy { get; set; }

    }
}
