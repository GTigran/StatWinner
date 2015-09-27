using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StatWinner.Common.Responses;

namespace StatWinner.Configuration.Interfaces
{
    /// <summary>
    /// Configuration Manager interface for loading and saving 
    /// </summary>
    public interface IConfigurationManager
    {

        /// <summary>
        /// Gets configuration item value
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        IConfigurationSetting GetConfigurationValue(string fieldName);

        /// <summary>
        /// Saves Configuration Value into corresponding data store
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        IConfigurationSetting SaveConfigurationSettingValue(string fieldName, object fieldValue);

        /// <summary>
        /// The list of Configuration Settings
        /// </summary>
        List<IConfigurationSetting> ConfigurationSettings { get; set; }

        BooleanResponse SaveConfigurationSettings();

    }
}
