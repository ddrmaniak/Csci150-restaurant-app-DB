using System.Configuration;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace AzureWebApplication
{
    public class ConfigHelper
    {
        /// <summary>
        /// Returns the value of the configuration setting called "OldSettingName1" 
        /// from either web.config, or the Azure Role Environment.
        /// </summary>
        public static string OldSettingName1
        {
            get
            {
                return RoleEnvironment.IsAvailable ?
                       RoleEnvironment.GetConfigurationSettingValue("OldSettingName1") :
                      ConfigurationManager.AppSettings["OldSettingName1"];
            }
        }

        /// <summary>
        /// Returns the value of the configuration setting called ”settingName”
        /// from either web.config, or the Azure Role Environment.
        /// </summary>
        public static string GetSettingAsString(string settingName)
        {
            return RoleEnvironment.IsAvailable ?
                   RoleEnvironment.GetConfigurationSettingValue(settingName) :
                  ConfigurationManager.AppSettings[settingName];
        }
    }
}