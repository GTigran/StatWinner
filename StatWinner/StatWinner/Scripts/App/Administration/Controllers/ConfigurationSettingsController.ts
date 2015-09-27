
module StatWinner.App.Administration {

    import CommonExtensions = StatWinner.Common.ControllerExtensions;

    export class ConfigurationSettingsController {

        static $inject = ['ConfigurationSettingsGridService'];

        constructor($scope: any,
            ConfigurationSettingsGridService: ConfigurationSettingsGridService) {

            $scope.$parent.currentSecion = "Configuration_Section";
            $scope.$parent.pageTitle = "Configuration Settings";

            angular.extend($scope, CommonExtensions.kendoGridManagementExtensions);
            ConfigurationSettingsGridService.PageSize = 10;
            ConfigurationSettingsGridService.ReloadDataSource(0);

            $scope.MainGridOptions = {
                dataSource: {
                    transport: {
                        read: function (options) { 
                            ConfigurationSettingsGridService.DatabaseChangedEventHandler = function (data: Array<IConfigurationSettingsGridModel>) {
                                $scope.kendoObservableArray.init(data);
                                options.success($scope.kendoObservableArray);
                            };
                        }
                    },
                    schema: {
                        total: function () {
                            return ConfigurationSettingsGridService.DataSourceLength();
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
                        field: "FieldName",
                        title: "Field Name",
                        template: "<input type='text' ng-model='dataItem.FieldName' ng-required='true' ng-model-options='{ allowInvalid: true }' is-changed='{{dataItem.IsElementValueChanged}}' transfer-validation='{{formFieldNameTd.$valid }}' name='FieldName' show-validation-error='{{dataItem.ShowValidationFields.FieldName}}' /><div validation-message error='{{formFieldNameTd.FieldName.$error}}' class='validation-error' show-validation-error='{{dataItem.ShowValidationFields.FieldName}}' ></div>",
                        attributes: { "ng-form": '', name: "formFieldNameTd" }
                    },
                    {
                        field: "FieldValue",
                        title: "Field Value",
                        template: "<input type='text' ng-model='dataItem.FieldValue' ng-required='true' ng-model-options='{ allowInvalid: true }' name='FieldValue' transfer-validation='{{formFieldValueTd.$valid }}' is-changed='{{dataItem.IsElementValueChanged}}' show-validation-error='{{dataItem.ShowValidationFields.FieldValue}}' /> <div validation-message error='{{formFieldValueTd.FieldValue.$error}}' class='validation-error' show-validation-error='{{dataItem.ShowValidationFields.FieldValue}}' ></div>",
                        attributes: { "ng-form": '', name: "formFieldValueTd" }
                    }
                ]
            };
            ConfigurationSettingsGridService.IsServerSidePaging = false;

            $scope.addNewRow = function () {
                var newItem = new ConfigurationSettingsGridModel(
                    {
                        Id: null,
                        FieldName: "",
                        FieldValue: ""
                    });
                $scope.kendoObservableArray.splice(0, 0, newItem);
            };

            $scope.saveChanges = function () {
                ConfigurationSettingsGridService.SaveChanges(this.kendoObservableArray, function () {
                    bootbox.alert("Configuration settings have been successfully saved");
                    ConfigurationSettingsGridService.ReloadDataSource(0);
                });
            }
        }
    }
    
    var app = angular.module("stat_winner_module");
    app.controller("ConfigurationSettingsController", ["$scope", "ConfigurationSettingsGridService", ConfigurationSettingsController]);

    

}