 module StatWinner.App.Administration {

    import Common = StatWinner.Common;
    
    export class ConfigurationSettingsGridModel extends Common.ModelBase {
        public Id: string;
        public FieldName: string;
        public FieldValue: string;

        constructor(data: IConfigurationSettingsGridModel) {
            this.Id = data.Id;
            this.FieldName = data.FieldName;
            this.FieldValue = data.FieldValue;
            super();
        }
    }
     
    export interface IConfigurationSettingsGridModel {
        Id: string;
        FieldName: string;
        FieldValue: string;
    }
}