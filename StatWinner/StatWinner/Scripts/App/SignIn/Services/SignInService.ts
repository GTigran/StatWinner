module StatWinner.App.SignIn {
    import CommonServices = StatWinner.Common.Services;
    import Constants = StatWinner.Common.Constants;
    import Common = StatWinner.Common;

    export class SignInService {
        static $inject = ['$http'];

        private $http: angular.IHttpService;

        public constructor($http: angular.IHttpService) {
            this.$http = $http;
        }

        public SignIn(model: SignInModel, callback: (result: Common.IBooleanResponse) => void) {
            var self = this;
            self.$http.post(Constants.AccountManagement.SignInUser, model).then(function(data: angular.IHttpPromiseCallbackArg<Common.IBooleanResponse>) {
                callback(data.data);
            });
        }
    }

    var app = angular.module("stat_winner_module");
    app.service("SignInService", ["$http", SignInService]);
}