using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using StatWinner.Configuration.Interfaces;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using StatWinner.Common;
using StatWinner.Common.Responses;
using StatWinner.CommonExtensions;

namespace StatWinner.Configuration.MongoDBProvider
{
    public class MongoDBConfigurationManager : IConfigurationManager
    {
        public MongoDBConfigurationManager()
        {
            this.MongoDbConnectionString = StatWinnerConfigurationManager.MongoDBConnectionString;
            this.MongoDbDatabaseName = StatWinnerConfigurationManager.StatWinnerDB;
            this.SkipExceptionLogging = true;

            try
            {
                this.MongoDbClient = new MongoClient(this.MongoDbConnectionString);
                this.MongoDatabase = this.MongoDbClient.GetDatabase(this.MongoDbDatabaseName);
                this.MongoConfigurationSettings = this.MongoDatabase.GetCollection<MongoConfigurationSetting>(StatWinnerConfigurationManager.ApplicationSettingsCollectionName);
                LoadConfigurations();
            }
            catch (Exception ex)
            {
                if (this.SkipExceptionLogging)
                {
                    //Call Api Method to do logging    
                }
            }
        }

        #region IConfigurationManager Implementation

        public void LoadConfigurations()
        {
            var sortDefinition = new SortDefinitionBuilder<MongoConfigurationSetting>();
            ConfigurationSettings = this.MongoConfigurationSettings.Find(_ => true).Sort(sortDefinition.Descending("_id")).ToListAsync().Result.Select(r => (IConfigurationSetting) r).ToList();
        }

        public IConfigurationSetting GetConfigurationValue(string fieldName)
        {


            throw new NotImplementedException();
        }

        public IConfigurationSetting SaveConfigurationSettingValue(string fieldName, object fieldValue)
        {
            throw new NotImplementedException();
        }

        public List<IConfigurationSetting> ConfigurationSettings { get; set; }

        public BooleanResponse SaveConfigurationSettings()
        {
            var insertList =
                this.ConfigurationSettings.Where(cs => cs.Id.IsNullOrWhiteSpace())
                    .Select(cs => (MongoConfigurationSetting)cs)
                    .ToList();

            insertList.ForEach(i => i.Id = ObjectId.GenerateNewId().ToString());

            var insertResponse = this.MongoConfigurationSettings.InsertManyAsync(insertList);
            

            var deleteList =
                this.ConfigurationSettings.Where(cs => cs.IsDeleted)
                    .Select(i => (MongoConfigurationSetting)i)
                    .ToList();

            var deleteFilter = Builders<MongoConfigurationSetting>.Filter.In("_id", deleteList.Select(d => d.Id));
            var deleteResponse = this.MongoConfigurationSettings.DeleteManyAsync(deleteFilter);

            //Iterate over existing elemnts and replace
            foreach (
                var setting in
                    this.ConfigurationSettings.Where(cs => !cs.Id.IsNullOrWhiteSpace() && !cs.IsDeleted)
                        .Select(i => (MongoConfigurationSetting) i)
                )
            {

                var updateFilter = Builders<MongoConfigurationSetting>.Filter.Eq("_id", setting.Id);
                var replaceResponse = this.MongoConfigurationSettings.ReplaceOneAsync(updateFilter, setting);
            }

            LoadConfigurations();

            return new BooleanResponse()
            {
                Result = true
            };
        }

        #endregion

        #region Properties

        private string MongoDbConnectionString { get; set; }

        private string MongoDbDatabaseName { get; set; }

        private bool SkipExceptionLogging { get; set; }

        private MongoClient MongoDbClient { get; set; }

        private IMongoDatabase MongoDatabase { get; set; }

        private string AppSettingsCollectionName { get; set; }

        private IMongoCollection<MongoConfigurationSetting> MongoConfigurationSettings { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Loads configuration data
        /// </summary>
        /// <param name="mongoDatabase"></param>
        private void LoadConfigurationData(IMongoDatabase mongoDatabase)
        {
            
        }

        #endregion
    }
}
