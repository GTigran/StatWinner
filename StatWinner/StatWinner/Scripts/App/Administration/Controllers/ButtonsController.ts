module StatWinner.App.Administration {


    import CommonExtensions = StatWinner.Common.ControllerExtensions;

    export class ButtonsController {
        static $inject = ["$scope"];
        constructor($scope: any) {

            $scope.saveChanges = function () {
                //Trigger main content button click
                this.$$nextSibling.saveChanges();
            }
        }
    }

    var app = angular.module("stat_winner_module");
    app.controller("ButtonsController", ButtonsController);

} 