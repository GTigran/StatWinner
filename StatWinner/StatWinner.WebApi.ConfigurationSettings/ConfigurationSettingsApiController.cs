using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using StatWinner.Common.Responses;
using StatWinner.Configuration.Interfaces;
using StatWinner.Configuration.MongoDBProvider;
using StatWinner.CommonExtensions;

namespace StatWinner.WebApi.ConfigurationSettings
{
    [RoutePrefix("api/ConfigurationSettingsApi")]
    public class ConfigurationSettingsApiController : ApiController
    {
        [HttpGet]
        [Route("Load")]
        public ListResponse<IConfigurationSetting> Load()
        {

            var response = new ListResponse<IConfigurationSetting>();

            try
            {
                var _manager =
                    StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IConfigurationManager>();
                var lst = _manager.ConfigurationSettings;
                response.Result = lst;
            }
            catch (Exception ex)
            {
            }

            return response;
        }

        [HttpPost]
        [Route("Save")]
        public BooleanResponse Save([FromBody]List<MongoConfigurationSetting> settings)
        {
            var manager =
                StatWinner.Common.DependencyInjection.DependencyContainer.GetInstance<IConfigurationManager>();

            var originalConfigurationSettings =
                manager.ConfigurationSettings;

            //Merge configuration settings
            foreach (var setting in settings)
            {
                if (setting.Id.IsNullOrWhiteSpace() || originalConfigurationSettings.All(c => c.Id != setting.Id))
                {
                    setting.Id = null;
                    originalConfigurationSettings.Add(setting);
                }
                else
                {
                    var originalSetting = originalConfigurationSettings.Single(c => c.Id == setting.Id);
                    originalSetting.FieldName = setting.FieldName;
                    originalSetting.FieldValue = setting.FieldValue;
                }
            }

            //Remove deleted ones from original collection
            foreach (var setting in originalConfigurationSettings)
            {
                if (settings.All(s => s.Id != setting.Id))
                {
                    setting.IsDeleted = true;
                }
            }

            var response = manager.SaveConfigurationSettings();
            return response;
        }
    }
}
