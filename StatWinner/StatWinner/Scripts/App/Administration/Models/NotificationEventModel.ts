module StatWinner.App.Administration {

    import Common = StatWinner.Common;
    import Responses = StatWinner.App.Administration.Responses;

    export class NotificationEventModel extends Common.ModelBase {

        public Id: string; 
        public EventKey: string;
        public Name: string;
        public Subject: string;
        public Body: string;
        public IsHtml: boolean;
        public DefaultFrom: string;
        public ToEmailAddresses: Array<string>;
        public ToEmailAddressesString: string;
        public SendEmailNotification: boolean;
        public SendSystemNotification: boolean;
        public EventCategoryId: string;
        public EventCategoryName: string;
        public IsUserSubscriptionRequired: boolean;
        public CreatedDate: Date;
        public CreatedBy: Responses.ICreatedByUser;
        public ModifiedDate: Date;
        public ModifiedBy: Responses.ICreatedByUser;

        constructor(data: Responses.INotificationEvent = null) {

            super();

            this.ToEmailAddressesString = "";

            if (data != null) {
                this.Id = data.Id;
                this.EventKey = data.EventKey;
                this.Name = data.Name;
                this.Subject = data.Subject;
                this.Body = data.Body;
                this.IsHtml = data.IsHtml;
                this.DefaultFrom = data.DefaultFrom;
                this.ToEmailAddresses = data.ToEmailAddresses;

                for (var i = 0; i < this.ToEmailAddresses.length; ++i) {
                    if (this.ToEmailAddressesString != "") {
                        this.ToEmailAddressesString += "";
                    }
                    this.ToEmailAddressesString += this.ToEmailAddresses[i];
                }

                this.SendEmailNotification = data.SendEmailNotification;
                this.SendSystemNotification = data.SendSystemNotification;
                this.EventCategoryId = data.EventCategoryId;
                this.EventCategoryName = data.EventCategoryName;
                this.IsUserSubscriptionRequired = data.IsUserSubscriptionRequired;
                this.CreatedDate = data.CreatedDate;
                this.CreatedBy = data.CreatedBy;
                this.ModifiedDate = data.ModifiedDate;
                this.ModifiedBy = data.ModifiedBy;
            } else {
                this.Id = null;
                this.EventKey = null;
                this.Name = null;
                this.Subject = null;
                this.Body = null;
                this.IsHtml = null;
                this.DefaultFrom = null;
                this.ToEmailAddresses = [];
                this.ToEmailAddressesString = "";
                this.SendEmailNotification = null;
                this.SendSystemNotification = null;
                this.EventCategoryId = null;
                this.EventCategoryName = null;
                this.IsUserSubscriptionRequired = null;
                this.CreatedDate = null;
                this.CreatedBy = {
                    Id: null,
                    EmailAddress: null,
                    FullName: null
                };
                this.ModifiedDate = null;
                this.ModifiedBy = {
                    Id: null,
                    EmailAddress: null,
                    FullName: null
                };
            }
        }
    }
}