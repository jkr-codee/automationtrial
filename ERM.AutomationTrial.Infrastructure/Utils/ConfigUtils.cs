using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERM.AutomationTrial.Infrastructure.Browser;

namespace ERM.AutomationTrial.Infrastructure.Utils
{
    /// <summary>
    /// Configuration utility class to retrieve application config values
    /// </summary>
    public static class ConfigUtils
    {
        public static BrowserType GetBrowserType()
        {
            string configValue = ConfigurationManager.AppSettings[Constants.ApplicationConfiguration.BrowserType];
            return (BrowserType) Enum.Parse(typeof(BrowserType), configValue);
        }

        public static string GetApplicationUrl()
        {
            return ConfigurationManager.AppSettings[Constants.ApplicationConfiguration.NopCommerceUrl];
        }

        public static string GetRestEndpoint()
        {
            return ConfigurationManager.AppSettings[Constants.ApplicationConfiguration.RestEndpoint];
        }
        public static string GetTempFolder()
        {
            return ConfigurationManager.AppSettings[Constants.ApplicationConfiguration.TempDataFolder];
        }
    }
}
