
module StatWinner.App.Administration {
    import CommonServices = StatWinner.Common.Services;
    import Constants = StatWinner.Common.Constants;
    import Common = StatWinner.Common;
    import Responses = StatWinner.App.Administration.Responses;
        
    export class NotificationEventsGridService extends StatWinner.Common.Services.GridServiceBaseModel<NotificationEventModel>
    {
        static $inject = ['$http', 'ValidatorService'];

        constructor(private $http: angular.IHttpService, private ValidatorService: CommonServices.ValidatorService ) {
            super();
            var self = this;
            this.ReloadDataSource = (page?: number): void => {
                $http.get(Constants.NotificationManagement.LoadNotificationEvents).then(function (data: angular.IHttpPromiseCallbackArg<Common.IListResponse<Responses.INotificationEvent>>) {
                    self.SetDataSource($.map(data.data.Result, function (dataItem) {
                        return new NotificationEventModel(dataItem);
                    }));
                });
            } 
        } 

        //Saving the changes
        public SaveChanges(data: NotificationEventModel, callback: () => void) : void {
            this.$http.post(Constants.NotificationManagement.SaveNotificationEvent, data, {
                isArray: true
            }).then(function (data: angular.IHttpPromiseCallbackArg<Common.IBooleanResponse>) {
                if (data.data.HasError) {
                    bootbox.alert(data.data.Errors[0].Message);
                } else {
                    callback();
                }
            });

        }
    }

    var app = angular.module("stat_winner_module");
    app.service("NotificationEventsGridService", ["$http", "ValidatorService", NotificationEventsGridService]);

}