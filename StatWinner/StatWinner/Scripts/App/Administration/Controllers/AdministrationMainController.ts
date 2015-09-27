module StatWinner.App.Administration {

    import CommonExtensions = StatWinner.Common.ControllerExtensions;

    export class AdministrationMainController {
        static $inject = [];

        constructor($scope: any) {
            $scope.pageTitle = "";
        }
    }

    var app = angular.module("stat_winner_module");
    app.controller("AdministrationMainController", ["$scope", AdministrationMainController]);
} 