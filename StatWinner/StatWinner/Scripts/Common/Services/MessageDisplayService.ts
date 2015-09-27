module StatWinner.Common.Services {

    export enum MessageLocation {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    export class MessageDisplayService {

        //Displays success message
        public DisplaySuccessMessage(message: string, messageLocation: MessageLocation = MessageLocation.TopRight, isHtml: boolean = false): void {
            this.DisplayMessage(message, messageLocation, "success", isHtml);
        }

        //Displays success message
        public DisplayInfoMessage(message: string, messageLocation: MessageLocation = MessageLocation.TopRight, isHtml: boolean = false): void {
            this.DisplayMessage(message, messageLocation, "info", isHtml);
        }

        //Displays success message
        public DisplayWarningMessage(message: string, messageLocation: MessageLocation = MessageLocation.TopRight, isHtml: boolean = false): void {
            this.DisplayMessage(message, messageLocation, "warning", isHtml);
        }

        //Displays success message
        public DisplayErrorMessage(message: string, messageLocation: MessageLocation = MessageLocation.TopRight, isHtml: boolean = false): void {
            this.DisplayMessage(message, messageLocation, "danger", isHtml);
        }

        private DisplayMessage(message: string, messageLocation: MessageLocation, messageType: string, isHtml: boolean): void {
            this.EnsureContainer(messageLocation);
            var cssClass = this.GetCssClassBasedOnLocation(messageLocation);

            $("." + cssClass).empty();
            $("." + cssClass).notify({
                message: {
                    text: message,
                    html: isHtml ? message : null
                },
                type: messageType,
                fadeOut: {
                    enabled: true,
                    delay: 5000
                }
            }).show();
        }

        //checkes whether container exists for message and if not adds it.
        private EnsureContainer(messageLocation: MessageLocation) {
            var cssClass = this.GetCssClassBasedOnLocation(messageLocation);

            if ($("BODY").find("." + cssClass).length == 0) {
                $("BODY").prepend(" <div class='notifications " + cssClass + "'></div>");
            }
        }

        private GetCssClassBasedOnLocation(messageLocation: MessageLocation): string {
            var cssClass = "";

            switch (messageLocation) {
            case MessageLocation.BottomLeft:
                cssClass = "bottom-left";
                break;
            case MessageLocation.BottomRight:
                cssClass = "bottom-right";
                break;
            case MessageLocation.TopLeft:
                cssClass = "top-left";
                break;
            case MessageLocation.TopRight:
                cssClass = "top-right";
                break;
            }
            return cssClass;
        }
    }

    var app = angular.module("stat_winner_module");
    app.service("MessageDisplayService", MessageDisplayService);
}