module StatWinner.App.Administration {

    adminConfiguration.$inject = ["$stateProvider"];
    function adminConfiguration($stateProvider: angular.ui.IStateProvider) {
        $stateProvider.state("configuration_settings", {
            url: "/confsettings",
            views: {
                rightTitleBar:
                {
                    templateUrl: "/Scripts/App/Administration/Templates/buttons-bar.html",
                    controller: "ButtonsController"
                },
                mainContent:
                {
                    templateUrl: "/Scripts/App/Administration/Templates/configuration_settings.html",
                    controller: "ConfigurationSettingsController"
                }
            }
        }).state("user_management", {
            url: "/usermngr", 
            views: {
                rightTitleBar:
                { 
                    templateUrl: "/Scripts/App/Administration/Templates/buttons-bar.html",
                    controller: "ButtonsController"
                },
                mainContent:
                {
                    template: "Moxes",
                    controller: "UserManagementController"
                }
            }
        }).state("notification_event_categories", {
            url: "/noteventcats",
            views: {
                rightTitleBar:
                {
                    templateUrl: "/Scripts/App/Administration/Templates/buttons-bar.html",
                    controller: "ButtonsController"
                },
                mainContent:
                {
                    templateUrl: "/Scripts/App/Administration/Templates/notificationEventsCategory.html",
                    controller: "NotificationEventCategoryController"
                }
            }
        }).state("notification_events", {
            url: "/notevents",
            views: {
                rightTitleBar:
                {
                    templateUrl: "/Scripts/App/Administration/Templates/buttons-bar.html",
                    controller: "ButtonsController"
                },
                mainContent:
                {
                    templateUrl: "/Scripts/App/Administration/Templates/notificationEvents.html",
                    controller: "NotificationEventsController" 
                }
            }
        }).state("otherwise", {
            url: "*path",
            views:
            {
                mainContent:
                {
                    templateUrl: "/Scripts/App/Administration/Templates/notFound.html"
                }
            }
        });
    } 

    var app = angular.module("stat_winner_module");
    app.config(adminConfiguration);
}