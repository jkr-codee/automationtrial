using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.AutomationTrial.Infrastructure
{

    /// <summary>
    /// Static class implement of extention methods for String type
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts give string value to an integer value
        /// if there is any error in the conversion then it returns the value as -1
        /// </summary>
        /// <param name="value">String value to be converted to integer</param>
        /// <returns>Integer value</returns>
        public static int ToInteger(this string value)
        {
            int returnValue = 0;
            return int.TryParse(value, out returnValue) ? returnValue : -1;
        }
    }
}
