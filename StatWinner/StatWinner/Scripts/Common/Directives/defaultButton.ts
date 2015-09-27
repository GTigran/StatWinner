module StatWinner.Common.Directives {

    function defaultButton(): angular.IDirective {

        var directive = <angular.IDirective> {
            restrict: "A",
            link: function(scope, element, attrs, ctrl) {

                var defaultButtonId = attrs["defaultButton"];
                element.on("keyup", function(e) {
                    if (e.which == 13) {
                        if (defaultButton != null) {
                            element.find("#" + defaultButtonId).trigger("click");
                        }
                    }
                });
            }
        }
        return directive;
    }
    angular.module("stat_winner_module").directive("defaultButton", defaultButton);
}