module StatWinner.Common.Services {

    export class ValidatorService {

        public ValidateItem<T extends ModelBase>(item: T) : boolean {
            item.ShowValidations();
            return item.IsValid; 
        }

        public ValidateList<T extends ModelBase>(items: Array<T>) {

            var isValid = true;
            for (var i = 0; i < items.length; ++i) {
                var item = items[i];
                isValid = this.ValidateItem(item) && isValid;
            }
            return isValid;
        }
    } 

    var app = angular.module("stat_winner_module");
    app.service("ValidatorService", ValidatorService); 
}