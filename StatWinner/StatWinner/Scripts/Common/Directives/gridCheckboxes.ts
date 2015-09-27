module StatWinner.Common.Directives {

    function gridSelectAllCheckbox(): angular.IDirective {

        var directive = <angular.IDirective> {
            restrict: "A",
            link: function (scope, element, attrs, ctrl) {
                element.on("click", function () {
                    var checked = $(this).prop("checked");
                    for (var i = 0; i < scope.$parent["kendoObservableArray"].length; ++i) {
                        scope.$parent["kendoObservableArray"][i].IsSelected = checked;
                    }
                    scope.$apply();
                });
            }
        }
        return directive;
    }
     
    angular.module("stat_winner_module").directive("gridSelectAllCheckbox", gridSelectAllCheckbox);

    function gridItemCheckbox(): angular.IDirective {

        var directive = <angular.IDirective> {
            restrict: "A",
            link: function (scope, element, attrs, ctrl) {
                scope.$watch("dataItem.IsSelected", function() {
                    if (!scope["dataItem"].IsSelected) {
                        scope.$parent["SelectAll"] = false;
                    } else {
                        var isSelectAll = true;
                        for (var i = 0; i < scope.$parent["kendoObservableArray"].length; ++i) {
                            if (!scope.$parent["kendoObservableArray"][i].IsSelected) {
                                isSelectAll = false;
                                break;
                            }
                        }
                    }
                    scope.$parent["SelectAll"] = isSelectAll;
                    scope.$apply();
                });
            }
        }
        return directive;
    }
    angular.module("stat_winner_module").directive("gridItemCheckbox", gridItemCheckbox);
}