using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ERM.AutomationTrial.Common
{
    /// <summary>
    /// Specflow extension method for table class
    /// </summary>
    public static class TableExtensionMethods
    {
        /// <summary>
        /// Converts given table from the feature to a Dictionary
        /// </summary>
        /// <param name="table">Spec flow table example</param>
        /// <returns>Dictionary of table values</returns>
        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}
