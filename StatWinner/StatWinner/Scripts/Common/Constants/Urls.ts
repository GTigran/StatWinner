module StatWinner.Common.Constants {
    
    export module ConfigurationSettings {
        export var LoadConfigurationSettings: string = "/api/ConfigurationSettingsApi/Load";
        export var SaveConfigurationSettings: string = "/api/ConfigurationSettingsApi/Save";
    }

    export module AccountManagement {
        export var LoadAllCountries: string = "/api/AccountRegistration/LoadAllCountries";
        export var UserRegistration: string = "/api/AccountRegistration/UserRegistration";
        export var SignInUser: string = "/api/AccountRegistration/SignInUser";
    }

    export module NotificationManagement
    {
        export var ListEventCategories: string = "/api/NotificationEvent/ListEventCategories";
        export var SaveEventCategories: string = "/api/NotificationEvent/SaveEventCategories";
        export var LoadNotificationEvents: string = "/api/NotificationEvent/LoadNotificationEvents";
        export var SaveNotificationEvent: string = "/api/NotificationEvent/SaveNotificationEvent";
    }
}
