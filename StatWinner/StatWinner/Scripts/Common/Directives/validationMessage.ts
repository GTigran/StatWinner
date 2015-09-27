module StatWinner.Common.Directives {

    module StatWinner.Common.Directives {

        function validationMessage(): angular.IDirective {

            var defaultErrorMessages = {
                required: "This field is required",
                minlength: "Min length validation was not met",
                maxlength:  "Max length validation was not met"
            };


            var directive = <angular.IDirective> {
                restrict: "EA", 
                link: function (scope, element, attrs, ctrl) {

                    element.attrchange({
                        trackValues: true,
                        callback: function (e) {
                            if (e.attributeName == "error") {
                                var error = JSON.parse(e.newValue);
                                var validationMessage = ""; 

                                for (var key in error) {
                                    var messageAttributeName = key + "Message";
                                    var currentMessage = null;
                                    if (attrs[messageAttributeName] != null) {
                                        currentMessage = attrs[messageAttributeName];
                                    } else {

                                        if (attrs[messageAttributeName.toLowerCase()] != null) {
                                            currentMessage = attrs[messageAttributeName.toLowerCase()];
                                        } else {
                                            currentMessage = defaultErrorMessages[key];    
                                        }
                                    }

                                    if (currentMessage != null && currentMessage != "") {

                                        if (validationMessage != "") {
                                            validationMessage += "<BR />";
                                        }
                                        validationMessage += currentMessage;
                                    }
                                }
                                element.html(validationMessage);
                            }
                        }
                    });
                }
            }
            return directive;
        }

        angular.module("stat_winner_module").directive("validationMessage", validationMessage);
    }
}