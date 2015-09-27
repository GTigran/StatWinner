
module StatWinner.App.Administration {
    import CommonServices = StatWinner.Common.Services;
    import Constants = StatWinner.Common.Constants;
    import Common = StatWinner.Common;
        
    export class ConfigurationSettingsGridService extends StatWinner.Common.Services.GridServiceBaseModel<ConfigurationSettingsGridModel>
    {
        static $inject = ['$http', 'ValidatorService'];



        constructor(private $http : angular.IHttpService, private ValidatorService) {
            super();
            var self = this;
            this.ReloadDataSource = (page?: number) : void => {
                $http.get(Constants.ConfigurationSettings.LoadConfigurationSettings).then(function (data: angular.IHttpPromiseCallbackArg<Common.IListResponse<ConfigurationSettingsGridModel>>) {
                    self.SetDataSource($.map(data.data.Result, function (dataItem) {
                        return new ConfigurationSettingsGridModel(dataItem);
                    }));
                });
            } 
        } 

        //Saving the changes
        public SaveChanges(data: Array<ConfigurationSettingsGridModel>, callback: () => void) : void {
            if (!this.ValidateData(data)) {
                bootbox.alert("Please fix validation errors");
                return;
            }

            var dataToPost = $.map(data, function (dataItem: ConfigurationSettingsGridModel) {
                return {
                    Id: dataItem.Id,
                    FieldName: dataItem.FieldName,
                    FieldValue: dataItem.FieldValue
                };
            });

            this.$http.post(Constants.ConfigurationSettings.SaveConfigurationSettings, dataToPost, {
                isArray: true
            }).then(function (data: angular.IHttpPromiseCallbackArg<Common.IBooleanResponse>) {

                if (data.data.HasError) {
                    bootbox.alert(data.data.Errors[0].Message);
                } else {
                    callback();
                }
            });

        }

        public ValidateData(data: Array<ConfigurationSettingsGridModel>) {
            var isValid = true;

            for (var i = 0; i < data.length; ++i) {
                isValid = data[i].IsValid && isValid;
                data[i].ShowValidations(); 
            }
            return isValid;
        }
    }

    var app = angular.module("stat_winner_module");
    app.service("ConfigurationSettingsGridService", ConfigurationSettingsGridService);

}