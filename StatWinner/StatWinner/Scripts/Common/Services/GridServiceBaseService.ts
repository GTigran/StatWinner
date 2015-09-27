module StatWinner.Common.Services {

    export class GridServiceBaseModel<T> {

        public DataSource: Array<T>;
        public CurrentPage: number = 0;
        public ReloadDataSource: (page?: number) => void;
        public LoadDataSource: (page?: number) => void;
        public TotalDataCount: number = 0;
        public PageSize: number = 0;
        public IsServerSidePaging: boolean = false;
        public DatabaseChangedEventHandler: (dataSource: Array<T>) => void;
        

        constructor() {
            this.DataSource = new Array<T>();
        }

        public ChangePage(page: number): void {
            this.ReloadDataSource(page);
            this.DatabaseChangedEventHandler(this.DataSource);
        }

        public SetDataSource(dataSource: Array<T>) {
            this.DataSource = dataSource;

            if (this.DatabaseChangedEventHandler != null) {
                this.DatabaseChangedEventHandler(this.DataSource);    
            }
        }

        public DataSourceLength(): number {
            return this.DataSource.length;
        }
    }
}
