module StatWinner.App.Registration {

    import Common = StatWinner.Common;

    export class RegistrationModel extends Common.ModelBase {

        public FirstName: string;
        public LastName: string;
        public CountryId: string;
        public State: string;
        public City: string;
        public Email: string;
        public Password: string;
        public ConfirmPassword: string;


        public constructor() {
            super();

            this.FirstName = null;
            this.LastName = null;
            this.CountryId = null;
            this.State = null;
            this.City = null;
            this.Email = null;
            this.Password = null;
            this.ConfirmPassword = null;
        }
    }
}