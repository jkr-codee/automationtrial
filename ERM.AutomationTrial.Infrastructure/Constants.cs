using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.AutomationTrial.Infrastructure
{
    /// <summary>
    /// Constant singleton class for defining all the constant values used
    /// by the Automation trial test application
    /// </summary>
    public static class Constants
    {
        public static class ApplicationConfiguration
        {
            public static string BrowserType = "BrowserType";
            public static string NopCommerceUrl = "NopCommerceUrl";
            public static string TempDataFolder = "TempDataFolder";
            public static string RestEndpoint = "RestEndpoint";
        }

        public static class WebFormContainerNames
        {
            public static string NewUserRegistration = "CreateUserForm_CreateUserStepContainer_";
            public static string Login = "ctrlCustomerLogin_LoginForm_";
        }
    }
}
