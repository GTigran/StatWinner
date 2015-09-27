module StatWinner.App.SignIn {

    import CommonExtensions = StatWinner.Common.ControllerExtensions;
    import CommonServices = StatWinner.Common.Services;
    import CommonModels = StatWinner.Common.Models;
    import Common = StatWinner.Common;
    
    export class SignInController {
        static $inject = [];

        constructor($scope: any,
            ValidatorService: CommonServices.ValidatorService,
            SignInService: SignInService,
            MessageDisplayService: CommonServices.MessageDisplayService
        ) {
            $scope.pageTitle = "";
            $scope.model = new SignInModel();
            $scope.errorMessage = null;

            $scope.SignIn = function() {
                if (!ValidatorService.ValidateItem(this.model)) {
                    bootbox.alert("Please fix validation errors");
                    return;
                }

                SignInService.SignIn(this.model, (result: Common.IBooleanResponse) => {
                    if (result.Result) {
                        document.location.href = "/";
                    } else {
                        //MessageDisplayService.DisplayErrorMessage(result.Errors[0].Message);
                        this.errorMessage = result.Errors[0].Message;

                        setTimeout(function () {
                            $scope.errorMessage = null;
                            $scope.$apply();
                        }, 5000);
                    }
                });
            };

            $scope.facebookLogin = function() {

                alert("facebookLogin");

            }
        }
    }

    var app = angular.module("stat_winner_module");
    app.controller("SignInController", ["$scope", "ValidatorService", "SignInService", "MessageDisplayService", SignInController]);
}