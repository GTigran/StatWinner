module StatWinner.Common.Directives {

    function configureContentHeight(): angular.IDirective {

        var setContentHeight = function($element) {
            var height = $(window).height();
            var contentHeight = height- 320;   
            $element.height(contentHeight);
        };

        var directive = <angular.IDirective> {
            restrict: "A",
            link: function (scope, $element, attrs, ctrl) {

                setContentHeight($element);
                $(window).on("scroll resize", function() {
                    setContentHeight($element);
                }); 
            }
        }
        return directive;
    }

    angular.module("stat_winner_module").directive("configureContentHeight", configureContentHeight);
}