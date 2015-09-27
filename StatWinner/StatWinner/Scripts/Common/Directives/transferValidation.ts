
module StatWinner.Common.Directives
{
    function transferValidation(): angular.IDirective {

        var directive = <angular.IDirective> {
            restrict: "A",
            link: (scope: any, element, attrs, ctrl) => {

                element.on("keyup paste change propertychange", function () {

                    var modelName = $(this).closest("[ng-form]").data("modelName");
                    if (modelName != null) {
                        if (modelName != null) {
                            scope[modelName].ShowFieldValidation(attrs["name"]);
                        } else {
                            scope.ShowFieldValidation(attrs["name"]);
                        }
                    } else {
                        //Checking dataItem in case if it is kendo Observable
                        if (scope.dataItem != null && scope.dataItem.IsValid != null) {
                            scope.dataItem.ShowFieldValidation(attrs["name"]);
                        }
                    }
                    scope.$apply();
                });
                element.attrchange({
                    trackValues: true,
                    callback: function (e) {
                        if (e.attributeName == "transfer-validation" ||
                                e.attributeName == "transferValidation"
                            ) {

                            //Checking dataItem in case if it is kendo Observable
                            if (scope.dataItem != null && scope.dataItem.IsValid != null) {
                                scope.dataItem.IsValid = (e.newValue == "true");
                            } else {
                                var modelName = $(this).closest("[ng-form]").data("modelName");
                                if (modelName != null) {
                                    scope[modelName].IsValid = (e.newValue == "true");
                                } else {
                                    scope.IsValid = (e.newValue == "true");
                                }
                            }
                             
                            scope.$apply();
                        }
                    }
                });
            }
        }
        return directive;
    }

    angular.module("stat_winner_module").directive("transferValidation", transferValidation);
}