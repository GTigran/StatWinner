module StatWinner.Common.Directives {


    function gridInPlaceModeManager($compile: angular.ICompileService): angular.IDirective {

        var directive = <angular.IDirective> {
            restrict: "A",
            link: function(scope, $element, attrs, ctrl) {
                $element.on("click", function() {
                    var $btn = $(this);
                    var $row = $btn.closest("TR");
                    var colspan = $row.find(">TD").length;
                    var inPlaceDirective = attrs["inPlaceDirective"];

                    if ($btn.hasClass("expand-icon")) {
                        $btn.removeClass("expand-icon").addClass("collapse-icon");
                        var $newHtml = "<TR class='in-place-row'><TD colspan='" + colspan + "'><" + inPlaceDirective + "></TD></TR>";
                        //Html should 
                        var $compiledHtml = $compile($newHtml)(scope);
                        $row.after($compiledHtml);
                    } else {
                        $btn.removeClass("collapse-icon").addClass("expand-icon");
                        if ($row.next().hasClass("in-place-row")) {
                            $row.next().remove();
                        }
                    }
                });
                

                scope["IsInPlaceEditOpen"] = null;

                scope.$watch("IsInPlaceEditOpen", function (newValue: boolean, oldValue: boolean) {
                    if (newValue != null) {
                        $element.trigger("click");    
                    }
                    
                });
            }
        }
        return directive;
    }
    angular.module("stat_winner_module").directive("gridInPlaceModeManager", ["$compile", gridInPlaceModeManager]);
}