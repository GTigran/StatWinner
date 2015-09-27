
module StatWinner.App.Administration {
    import CommonExtensions = StatWinner.Common.ControllerExtensions;

    export class NotificationEventsController {

        static $inject = ['NotificationEventsGridService'];

        constructor($scope: any,
            NotificationEventsGridService: NotificationEventsGridService) {

            $scope.$parent.currentSecion = "Notification_Events";
            $scope.$parent.pageTitle = "Event Management";
            angular.extend($scope, CommonExtensions.kendoGridManagementExtensions);
            NotificationEventsGridService.PageSize = 10;
            NotificationEventsGridService.ReloadDataSource(0);

            $scope.MainGridOptions = {
                dataSource: {
                    transport: {
                        read: function (options) {
                            NotificationEventsGridService.DatabaseChangedEventHandler = function (data: Array<NotificationEventModel>) {
                                $scope.kendoObservableArray.init(data);
                                options.success($scope.kendoObservableArray);
                            };
                        }
                    },
                    data: $scope.kendoObservableArray,
                    schema: {
                        total: function () {
                            return NotificationEventsGridService.DataSourceLength();
                        }
                    }
                },
                sortable: true,
                resizable: true,
                scrollable: true,
                pageable: {
                    input: true,
                    pageSize: 10
                },
                columns: [
                    {
                        field: "",
                        title: " ",
                        width: 40,
                        template: "<INPUT type='checkbox' ng-model='dataItem.IsSelected' grid-item-checkbox />",
                        headerTemplate: "<INPUT type='checkbox' ng-checked='$parent.SelectAll' grid-select-all-checkbox />"
                    },
                    {
                        field: "",
                        title: "",
                        width: 40,
                        template: "<div class='expand-icon' grid-in-place-mode-manager in-place-directive='manage-events-in-place-edit'  ></div>"
                    },
                    {
                        field: "EventKey",
                        title: "Event Key",
                        width: 150
                    },
                    {
                        field: "EventCategoryName",
                        title: "Event Category",
                        width: 150
                    },
                    {
                        field: "Name",
                        title: "Name",
                        width: 150
                    },
                    {
                        field: "Subject",
                        title: "Subject",
                        width: 200
                    },
                    {
                        field: "Body",
                        title: "Body",
                        width: 200
                    },
                    {
                        field: "IsHtml",
                        title: "Is Html",
                        width: 150,
                        template: "# if(IsHtml) {# Yes #} else {# No #}#"
                    },
                    {
                        field: "ToEmailAddressesString",
                        title: "To Email Addresses",
                        width: 200
                    },
                    {
                        field: "SendEmailNotification",
                        title: "Send Email Notification",
                        width: 150,
                        template: "# if(SendEmailNotification) {# Yes #} else {# No #}# "
                    },
                    {
                        field: "SendSystemNotification",
                        title: "Send System Notifcation",
                        width: 150,
                        template: "# if(SendSystemNotification) {# Yes #} else {# No #}# "
                    },
                    {
                        field: "IsUserSubscriptionRequired",
                        title: "User Subscription Required",
                        width: 150,
                        template: "# if(IsUserSubscriptionRequired) {# Yes #} else {# No #}# "
                    },
                    {
                        field: "IsUserSubscriptionRequired",
                        title: "Is User Subscription Required",
                        width: 150,
                        template: "# if(IsUserSubscriptionRequired) {# Yes #} else {# No #}# "
                    },
                    {
                        field: "CreatedDate",
                        title: "Created Date",
                        width: 150
                    },
                    {
                        field: "CreatedBy.FullName",
                        title: "Created By",
                        width: 200
                    },
                    {
                        field: "ModifiedDate",
                        title: "Modified Date",
                        width: 150
                    },
                    {
                        field: "ModifiedBy.FullName",
                        title: "Modified By",
                        width: 200
                    }
                ]
            };

            NotificationEventsGridService.IsServerSidePaging = false;

            $scope.addNewRow = function () {
                var newItem = new NotificationEventModel();
                $scope.kendoObservableArray.splice(0, 0, newItem);
            };

            $scope.saveChanges = function (model: NotificationEventModel) {
                debugger;
                NotificationEventsGridService.SaveChanges(model, function () {
                    bootbox.alert("Notification events have been successfully saved");
                    NotificationEventsGridService.ReloadDataSource(0);
                });
            }
        }
    }

    var app = angular.module("stat_winner_module");
    app.controller("NotificationEventsController", ["$scope", "NotificationEventsGridService", NotificationEventsController]);

    

    
}  