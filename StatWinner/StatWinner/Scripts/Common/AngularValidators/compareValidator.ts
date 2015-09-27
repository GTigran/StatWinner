module StatWinner.Common.Directives {

    var directiveId = "compareValidator";
    function compareValidator() {
        return {
            restrict: 'A',
            require: ['^form', 'ngModel'],
            link: function (scope, el, attrs, ctrls) {

                var
                    ngForm = ctrls[0],
                    shouldProcess,
                    handleChange,
                    setValidation,
                    ngModel = ctrls[1],
                    options = {
                        compareValidatorOperator: "eq",
                        compareValidatorOtherfield: null,
                        compareValidatorValue: null
                    };

                angular.extend(options, attrs);

                shouldProcess = function (value) {
                    var otherRulesInValid = false;
                    for (var p in ngModel.$error) {
                        var checkedKey = !options.hasOwnProperty('keys') ||
                            !(Object.keys(options["keys"])
                                .filter(function (k) {
                                    return options["keys"][k] === p;
                                })[0]);
                        if (ngModel.$error[p] && p != directiveId && checkedKey) {
                            otherRulesInValid = true;
                            break;
                        }
                    }
                    return !(ngModel.$pristine || otherRulesInValid);
                };

                setValidation = function (value) {
                    if (!shouldProcess(value)) {
                        ngModel.$setValidity(directiveId, true);
                        return;
                    }

                    if (typeof value === 'undefined' || value === '') {
                        ngModel.$setPristine();
                        ngModel.$setValidity(directiveId, true);
                        return;
                    }

                    var otherValue = options.compareValidatorValue;

                    if (otherValue == null && options.compareValidatorOtherfield != null) {
                        otherValue = ngForm[options.compareValidatorOtherfield].$viewValue;
                    }

                    if (otherValue == null || otherValue == "") {
                        ngModel.$setValidity(directiveId, true);
                        return;
                    }

                    switch (options.compareValidatorOperator) {
                        case "eq":
                            ngModel.$setValidity(directiveId, compareValues(value, otherValue) == 0);   
                            break;
                    }
                    return true;
                };


                scope.$watch(function () {
                    return ngModel.$viewValue;
                }, setValidation);

                if (options.compareValidatorOtherfield != null) {
                    scope.$watch(function() {
                        return ngForm[options.compareValidatorOtherfield].$viewValue;
                    }, function() {
                        setValidation(el.val());
                    });
                }
            }
        };
    }

    function compareValues(val1, val2) {
        
        if (val1 == val2) {
            return 0;
        }

        if (val1 > val2) {
            return 1;
        }

        return -1;
    }

    angular.module("stat_winner_module").directive(directiveId, compareValidator);



}