module StatWinner.Common.Directives {

    function leftPaneShowHide(): angular.IDirective {

        var leftPaneShowHide = function($element) {
            var height = $(window).height();
            var contentHeight = height - 394;
            $element.height(contentHeight);
        };

        var directive = <angular.IDirective> {
            restrict: "A",
            link: function (scope, $element, attrs, ctrl) {

                var $leftPane = $(".left-pane");
                 
                $element.on("click", function () {
                    $leftPane.addClass("show"); 
                    $element.hide();
                });

                $("BODY").on("click", function (e: JQueryEventObject) {

                    if ($(e.target).closest(".left-pane").length == 0 &&
                        $(e.target).closest("#left-pane-toggle").length == 0) {
                        $leftPane.removeClass("show");
                        $element.show();                        
                    }
                });
            }
        }
        return directive;
    }

    angular.module("stat_winner_module").directive("leftPaneShowHide", leftPaneShowHide);
}