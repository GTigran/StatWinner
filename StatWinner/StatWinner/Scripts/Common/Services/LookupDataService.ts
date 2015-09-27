module StatWinner.Common.Services {

    import CommonModels = StatWinner.Common.Models;
    import Administration = StatWinner.App.Administration;

    export enum LookupTypes {
        Countries,
        EventCategories
    }


    export class LookupDataService {

        static inject = ["$http"];
        private $http: angular.IHttpService;

        public constructor($http: angular.IHttpService) {
            this.$http = $http;
        }

        public LoadLookupService(lookupType: LookupTypes, list: kendo.data.ObservableArray, insertEmptyItem: boolean = true, idField: string = "id", nameField: string = "name"): void {


            var localList = new Array<StatWinner.Common.Models.DropDownModel>();

            switch (lookupType) {
            case LookupTypes.Countries:

                    var localList = new Array<StatWinner.Common.Models.DropDownModel>();
                if (insertEmptyItem) {
                    localList.push(new StatWinner.Common.Models.DropDownModel("", "-Select Country-"));
                }

                this.$http.get(Constants.AccountManagement.LoadAllCountries).then(function (data: angular.IHttpPromiseCallbackArg<Common.IListResponse<StatWinner.Common.Models.CountryModel>>) {

                    if (!data.data.HasError && data.data.Result != null) {
                        var countires = data.data.Result;
                        for (var i = 0; i < countires.length; ++i) {
                            var country = countires[i];
                            var dropdownItem = new StatWinner.Common.Models.DropDownModel(country.Id, country.NiceName);
                            localList.push(dropdownItem);
                        }
                        //This how we pass array to observable array
                        list.push.apply(list, localList);

                    } else {
                        if (data.data.HasError) {
                            alert(data.data.Errors[0].Message);
                        } else {
                            alert("Error occured while loading the list of countries. Please contact administration to resolve this issue.");
                        }
                    }
                });
                break;

            case LookupTypes.EventCategories:

                    if (insertEmptyItem) {
                        localList.push(new StatWinner.Common.Models.DropDownModel("", "-Select Event Category-"));
                    }

                    this.$http.get(Constants.NotificationManagement.ListEventCategories).then(function (data: angular.IHttpPromiseCallbackArg<Common.IListResponse<StatWinner.App.Administration.NotificationEventCategoryModel>>) {

                        if (!data.data.HasError && data.data.Result != null) {
                            var notificationEventCategories = data.data.Result;
                            for (var i = 0; i < notificationEventCategories.length; ++i) {
                                var notEventCategory = notificationEventCategories[i];
                                var dropdownItem = new StatWinner.Common.Models.DropDownModel(notEventCategory.Id, notEventCategory.Name);
                                localList.push(dropdownItem);
                            }
                            //This how we pass array to observable array
                            list.push.apply(list, localList);

                        } else {
                            if (data.data.HasError) {
                                alert(data.data.Errors[0].Message);
                            } else {
                                alert("Error occured while loading the list of countries. Please contact administration to resolve this issue.");
                            }
                        }
                    });
                    break;
            }
        }
    }

    var app = angular.module("stat_winner_module");
    app.service("LookupDataService", ["$http", LookupDataService]);
}