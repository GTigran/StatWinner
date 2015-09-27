module StatWinner.App.Registration {
    import CommonServices = StatWinner.Common.Services;
    import Constants = StatWinner.Common.Constants;
    import Common = StatWinner.Common;

    export class RegistrationService {
        static $inject = ['$http'];

        private $http: angular.IHttpService;
        public constructor($http: angular.IHttpService) {
            this.$http = $http;
        }

        public RegisterUser(model: RegistrationModel) {

            var self = this;
            self.$http.post(Constants.AccountManagement.UserRegistration, model).then(function (data: angular.IHttpPromiseCallbackArg<Common.IBooleanResponse>) {

                if (data.data.Result) {
                    bootbox.alert("Registration has been successfully processed! Please click 'OK' button to manage your account.", function() {
                        document.location.href = "/";
                    });
                } else {
                    var errorMessage = "";
                    for (var i = 0; i < data.data.Errors.length; ++i) {
                        if (errorMessage != "") {
                            errorMessage += "<BR />";
                        }
                        errorMessage += data.data.Errors[i].Message;
                    }
                    bootbox.alert(errorMessage);
                }
            });
        }
    }

    var app = angular.module("stat_winner_module");
    app.service("RegistrationService", ["$http", RegistrationService]);
}