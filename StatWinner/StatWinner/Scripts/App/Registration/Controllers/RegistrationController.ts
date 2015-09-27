module StatWinner.App.Registration {

    import CommonExtensions = StatWinner.Common.ControllerExtensions;
    import CommonServices = StatWinner.Common.Services;
    import CommonModels = StatWinner.Common.Models;

    export class RegistrationController {
        static $inject = [];

        constructor($scope: any,
            ValidatorService: CommonServices.ValidatorService,
            LookupDataService: CommonServices.LookupDataService,
            RegistrationService : RegistrationService
            ) {
            $scope.pageTitle = "";
            $scope.model = new RegistrationModel();

            $scope.Countries = new kendo.data.ObservableArray([]);
            LookupDataService.LoadLookupService(CommonServices.LookupTypes.Countries, $scope.Countries);
            
            $scope.EmailSetArgs = function (val, el, attrs, ngModel) {
                return { email: val, userId: null };
            }; 

            $scope.Register = function () {
                if (!ValidatorService.ValidateItem(this.model)) {
                    bootbox.alert("Please fix validation errors");
                    return;
                }
                
                RegistrationService.RegisterUser(this.model);
            };
        } 
    }

    var app = angular.module("stat_winner_module");
    app.controller("RegistrationController", ["$scope", "ValidatorService", "LookupDataService", "RegistrationService", RegistrationController]);
}