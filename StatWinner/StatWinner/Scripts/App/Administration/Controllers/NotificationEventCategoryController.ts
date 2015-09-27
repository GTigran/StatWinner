
module StatWinner.App.Administration {
    import CommonExtensions = StatWinner.Common.ControllerExtensions;

    export class NotificationEventCategoryController {

        static $inject = ['ConfigurationSettingsGridService'];

        constructor($scope: any,
            NotificationEventCategoryGridService: NotificationEventCategoryGridService) {

            $scope.$parent.currentSecion = "Notification_Event_Categories";
            $scope.$parent.pageTitle = "Event Category Management";

            angular.extend($scope, CommonExtensions.kendoGridManagementExtensions);
            NotificationEventCategoryGridService.PageSize = 10;
            NotificationEventCategoryGridService.ReloadDataSource(0);

            $scope.MainGridOptions = {
                dataSource: {
                    transport: {
                        read: function (options) {
                            NotificationEventCategoryGridService.DatabaseChangedEventHandler = function (data: Array<NotificationEventCategoryModel>) {
                                $scope.kendoObservableArray.init(data);
                                options.success($scope.kendoObservableArray);
                            };
                        }
                    },
                    schema: {
                        total: function () {
                            return NotificationEventCategoryGridService.DataSourceLength();
                        }
                    }
                },
                sortable: true,
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
                        field: "Name",
                        title: "Name",
                        template: "<input type='text' ng-model='dataItem.Name' ng-required='true' ng-model-options='{ allowInvalid: true }' name='Name' transfer-validation='{{formNameTd.$valid }}' is-changed='{{dataItem.IsElementValueChanged}}' show-validation-error='{{dataItem.ShowValidationFields.Name}}' class='hundreed_percent' /> <div validation-message error='{{formNameTd.Name.$error}}' class='validation-error' show-validation-error='{{dataItem.ShowValidationFields.Name}}'  ></div>",
                        attributes: { "ng-form": '', name: "formNameTd" }
                    }
                ]
            };

            NotificationEventCategoryGridService.IsServerSidePaging = false;

            $scope.addNewRow = function () {
                var newItem = new NotificationEventCategoryModel(
                    {
                        Id: null,
                        Name: ""
                    });
                $scope.kendoObservableArray.splice(0, 0, newItem);
            };

            $scope.saveChanges = function () {
                NotificationEventCategoryGridService.SaveChanges(this.kendoObservableArray, function () {
                    bootbox.alert("Notification events have been successfully saved");
                    NotificationEventCategoryGridService.ReloadDataSource(0);
                });
            }
        }
    }

    var app = angular.module("stat_winner_module");
    app.controller("NotificationEventCategoryController", ["$scope", "NotificationEventCategoryGridService", NotificationEventCategoryController]);

    

    
}  