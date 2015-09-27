module StatWinner.Common {


    export interface IError {
        StackTrace: string;
        Message: string;
        OriginalMessage: string;
        IDField: string;
    }

    export interface IBaseResponse {
        HasError: boolean;
        Errors: Array<IError>;
        PreviewBaseURL: string;
    }

    export interface IObjectResponse<T> extends IBaseResponse {
        Result: T;
    }

    export interface IListResponse<T> extends IBaseResponse {
        Result: Array<T>;
        TotalCount: number;
        PageIndex: number;
        PageSize: number;
    }

    export interface IInt32Response extends IBaseResponse {
        Result: number;
    }

    export interface IBooleanResponse extends IBaseResponse {
        Result: boolean;
    }
}