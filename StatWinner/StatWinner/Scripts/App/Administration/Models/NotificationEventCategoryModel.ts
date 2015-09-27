module StatWinner.App.Administration {

    import Responses = StatWinner.App.Administration.Responses;

    export class NotificationEventCategoryModel extends Common.ModelBase {
        public Id: string;
        public Name: string;

        public constructor(data: Responses.INotificationEventCategory = null) {
            super();

            if (data != null) {

                this.Id = data.Id;
                this.Name = data.Name;

            } else {
                this.Id = null;
                this.Name = null;                
            }
        }
    }
}