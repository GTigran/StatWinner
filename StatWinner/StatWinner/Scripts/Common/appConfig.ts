module StatWinner.Common {

    config.$inject = ["$locationProvider"];

    function config($locationProvider: angular.ILocationProvider,
        $stateProvider: angular.ui.IStateProvider) {
        $locationProvider.html5Mode(true);
    }

    var app = angular.module("stat_winner_module", ["kendo.directives", "ui.router"]).config(config);
}