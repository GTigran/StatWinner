module StatWinner.App.SignIn {

    import Common = StatWinner.Common;

    export class SignInModel extends Common.ModelBase {

        public Email: string;
        public Password: string;
        public RememberMe: boolean;

        public constructor() {
            super();

            this.Email = null;
            this.Password = null;
            this.RememberMe = false;
        }
    }
}