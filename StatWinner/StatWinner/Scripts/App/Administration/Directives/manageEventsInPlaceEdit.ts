module StatWinner.App.Administration {

    import CommonServices = StatWinner.Common.Services;

    function manageEventsInPlaceEdit(LookupDataService: CommonServices.LookupDataService,
                                    ValidatorService: CommonServices.ValidatorService
        ): angular.IDirective {

        var directive = <angular.IDirective> {
            restrict: "E",
            scope: {
                notificationEventForm: "="
            },
            templateUrl: "/Scripts/App/Administration/Templates/notificationEventInPlaceTemplate.html",
            link: function (scope, $element, attrs, ctrl) {
                scope["model"] = new NotificationEventModel(scope.$parent["dataItem"]);

                scope["EventCategories"] = new kendo.data.ObservableArray([]);
                LookupDataService.LoadLookupService(CommonServices.LookupTypes.EventCategories, scope["EventCategories"]);
                $element.find("SELECT").kendoDropDownList({
                    dataValueField: "id",
                    dataTextField: "name",
                    dataSource: scope["EventCategories"]
                });

                $("TEXTAREA").kendoEditor({
                    resizable: {
                        content: true,
                        toolbar: true
                    },
                    tools: [
                        "bold",
                        "italic",
                        "underline",
                        "strikethrough",
                        "justifyLeft",
                        "justifyCenter",
                        "justifyRight",
                        "justifyFull",
                        "insertUnorderedList",
                        "insertOrderedList",
                        "indent", 
                        "outdent",
                        "createLink",
                        "unlink",
                        "insertImage",
                        "insertFile",
                        "subscript",
                        "superscript",
                        "createTable",
                        "addRowAbove",
                        "addRowBelow",
                        "addColumnLeft",
                        "addColumnRight",
                        "deleteRow",
                        "deleteColumn",
                        "viewHtml",
                        "formatting",
                        "cleanFormatting",
                        "fontName",
                        "fontSize",
                        "foreColor",
                        "backColor",
                        "print"
                    ]
                });

                scope["SaveEvent"] = function () {
                    if (!ValidatorService.ValidateItem(this.model)) {
                        bootbox.alert("Please fix validation errors.");
                        return;
                    }
                    
                   scope.$parent["saveChanges"](this.model);
                }

                scope["CancelEvent"] = function() {
                    scope.$parent["IsInPlaceEditOpen"] = false;
                }
            }
        }
        return directive;
    }

    angular.module("stat_winner_module").directive("manageEventsInPlaceEdit", ["LookupDataService", "ValidatorService", manageEventsInPlaceEdit]);
}