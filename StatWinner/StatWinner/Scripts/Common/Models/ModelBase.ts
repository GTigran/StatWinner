module StatWinner.Common {
    export class ModelBase {
        public IsValid: boolean;
        public ShowValidationFields: any;
        public IsSelected: boolean;
        constructor() {
            this.IsValid = true;
            this.ShowValidationFields = {};
            this.IsSelected = false;
            this.ShowValidations(false);
        }

        public ShowValidations(show: boolean = true) {
            for (var key in this) {

                if (key != "IsValid" &&
                        key != "constructor" &&
                        key != "ShowValidationFields" &&
                        key != "IsSelected" &&
                        key != "ShowValidations" &&
                        key != "ShowFieldValidation"
                ) {
                    this.ShowValidationFields[key] = show;    
                }
            }
        }

        public ShowFieldValidation(field: string, show: boolean = true): void {
            this.ShowValidationFields[field] = show;
        }
    }
}