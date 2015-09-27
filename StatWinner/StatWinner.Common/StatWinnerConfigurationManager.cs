using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Framework.Configuration;

namespace StatWinner.Common
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class StatWinnerConfigurationManager
    {
        // public static IConfiguration Configuration { get; set; }

        public static string SiteTitle
        {
            get { return ConfigurationManager.AppSettings["SiteTitle"]; }
        }

        public static string MongoDBConnectionString
        {
            get { return ConfigurationManager.AppSettings["MongoDBConnectionString"]; }
        }

        public static string StatWinnerDB
        {
            get { return ConfigurationManager.AppSettings["StatWinnerDB"]; }
        }

        public static string IdentityDB
        {
            get { return ConfigurationSettings.AppSettings["IdentityDB"]; }
        }

        public static string ApplicationSettingsCollectionName
        {
            get { return ConfigurationManager.AppSettings["ApplicationSettingsCollectionName"]; }
        }

        public static string LoggerDB
        {
            get { return ConfigurationManager.AppSettings["ApplicationSettingsCollectionName"]; }
        }

        public static string NotificationDB
        {
            get { return ConfigurationManager.AppSettings["NotificationDB"]; }
        }
    }
}
