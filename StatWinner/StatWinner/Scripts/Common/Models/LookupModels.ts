module StatWinner.Common.Models {

    export class DropDownModel {
        public id: string;
        public name: string;

        public constructor(id: string, name: string) {
            this.id = id;
            this.name = name;
        }
    }

    export class CountryModel {
        public Id: string;
        public ISO: string;
        public Name: string;
        public NiceName: string;
        public Iso3: string;
        public NumCode: string;
        public PhoneCode: string;
        public SortIndex: string;
    }
}