
module StatWinner.App.Administration {

    import CommonExtensions = StatWinner.Common.ControllerExtensions;

    export class UserManagementController {

        constructor($scope: any) {
            $scope.$parent.currentSecion = "User_Management";
            $scope.$parent.pageTitle = "User Management";

            $scope.saveChanges = function () {
                alert("CHURBAN");
            }
        }
    }
    
    var app = angular.module("stat_winner_module");
    app.controller("UserManagementController", ["$scope", UserManagementController]);

    

} 