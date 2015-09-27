

module StatWinner.App.Administration {
    import CommonServices = StatWinner.Common.Services;
    import Constants = StatWinner.Common.Constants;
    import Common = StatWinner.Common;
    import Responses = StatWinner.App.Administration.Responses.INotificationEventCategory;

    export class NotificationEventCategoryGridService extends StatWinner.Common.Services.GridServiceBaseModel<NotificationEventCategoryModel> {
        static $inject = ['$http', 'ValidatorService'];

        constructor(private $http: angular.IHttpService, private ValidatorService: CommonServices.ValidatorService) {
            super();
            var self = this;
            this.ReloadDataSource = (page?: number): void => {
                $http.get(Constants.NotificationManagement.ListEventCategories).then((data: angular.IHttpPromiseCallbackArg<Common.IListResponse<Responses.INotificationEventCategory>>) => {

                    self.SetDataSource($.map(data.data.Result, function (dataItem) {
                        return new NotificationEventCategoryModel(dataItem);
                    }));
                });
            }
        }

        //Saving the changes
        public SaveChanges(data: Array<NotificationEventCategoryModel>, callback: () => void): void {
            if (!this.ValidatorService.ValidateList(data)) {
                bootbox.alert("Please fix validation errors");
                return;
            }

            debugger;
            var dataToPost = $.map(data, function (dataItem: NotificationEventCategoryModel) {
                return {
                    Id: dataItem.Id,
                    Name: dataItem.Name
                };
            });

            this.$http.post(Constants.NotificationManagement.SaveEventCategories, dataToPost, {
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
    app.service("NotificationEventCategoryGridService", ["$http", "ValidatorService", NotificationEventCategoryGridService]);
}