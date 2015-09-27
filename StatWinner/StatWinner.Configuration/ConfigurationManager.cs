using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatWinner.Common.Responses;
using StatWinner.Configuration.Interfaces;

namespace StatWinner.Configuration
{
    /// <summary>
    /// Main exit point class managing configuration settings
    /// </summary>
    public class ConfigurationSettings
    {
        public ConfigurationSettings(IConfigurationManager configurationManager)
        {
            this.ConfigurationManager = configurationManager;
        }

        #region Properties

        private IConfigurationManager ConfigurationManager { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets configuration field value
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public object GetConfigurationFieldValue(string fieldName)
        {
            var configurationSetting =
                this.ConfigurationManager.ConfigurationSettings.FirstOrDefault(cs => cs.FieldName == fieldName);

            return configurationSetting?.FieldValue;
        }

        /// <summary>
        /// Saves configuration value
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        public void SaveConfigurationValue(string fieldName, object fieldValue)
        {
            this.ConfigurationManager.SaveConfigurationSettingValue(fieldName, fieldValue);
        }

        /// <summary>
        /// Saves configuration settings
        /// </summary>
        /// <returns></returns>
        public BooleanResponse SaveConfigurationSettings()
        {
            ConfigurationManager.SaveConfigurationSettings();

            return new BooleanResponse()
            {
                Result = true
            };
        }

        public List<IConfigurationSetting> ConfigurationSettingsList
        {
            get { return this.ConfigurationManager.ConfigurationSettings; }
        }

        #endregion Methods
    }
}
