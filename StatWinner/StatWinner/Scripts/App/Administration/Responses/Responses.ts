module StatWinner.App.Administration.Responses {

    export interface ICreatedByUser {
        Id: string;
        EmailAddress: string;
        FullName: string;
    }

    export interface INotificationEventCategory {
        Id: string;
        Name: string;
    }

    export interface INotificationEvent {
        Id: string; 
        EventKey: string;
        Name: string;
        Subject: string;
        Body: string;
        IsHtml: boolean;
        DefaultFrom: string;
        ToEmailAddresses: Array<string>;
        SendEmailNotification: boolean;
        SendSystemNotification: boolean;
        EventCategoryId: string;
        EventCategoryName: string;
        IsUserSubscriptionRequired: boolean;
        CreatedDate: Date;
        CreatedBy: ICreatedByUser;
        ModifiedDate: Date;
        ModifiedBy: ICreatedByUser;
    }
}