using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERM.AutomationTrial.Infrastructure;
using ERM.AutomationTrial.Infrastructure.Entity;
using ERM.AutomationTrial.Infrastructure.Helpers;
using ERM.AutomationTrial.Infrastructure.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
namespace ERM.AutomationTrial.Api
{
    public class TypeCodeApi: BaseApi
    {
        protected static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IList<Post> _apiData;
        public TypeCodeApi()
        {
            _log.Info("Helper created");
            _restHelper = new RestHelper();
        }

        public void LoadData()
        {
            _apiData = _restHelper.GetData<Post>();
            _log.Info($"Data loaded from Rest Api {0}");
        }

        public void CheckTitleOfPosts(Table table)
        {
            _log.Info($"Checking the titles of the data based on the scenario");
            foreach (var testData in table.Rows)
            {
                var id = testData["id"].ToInteger();
                var foundRecord = _apiData.FirstOrDefault(p => p.Id == id);
                Assert.IsNotNull(foundRecord);
                Assert.IsTrue(foundRecord.Title == testData["title"]);
            }
        }

        public void CheckNumberOfRecordsForEachUser(Table table)
        {
            _log.Info($"Counting number of records for each user");
            foreach (var testData in table.Rows)
            {
                var userId = testData["userid"].ToInteger();
                var foundRecords = _apiData.Count(p => p.UserId == userId);
                Assert.AreEqual(foundRecords, testData["count"].ToInteger());
            }
        }

        public bool AreThereAnyBlanks()
        {
            _log.Info($"Checking for blanks in the data fields");
            return _apiData.Any(d => !d.UserId.HasValue || !d.Id.HasValue || string.IsNullOrEmpty(d.Title) || string.IsNullOrEmpty(d.Body));
        }

        public bool AreThereAnyDuplicateTitles()
        {
            _log.Info($"Checking for duplicate titles from the data");
            var duplicateCounts = from item in _apiData
                group item.Title by new { item.Title }
                into g
                where g.Count() > 1
                select g.Key;
            return duplicateCounts.Any();
        }

        public void SetEndpoint()
        {
            _restHelper.SetEndpoint(ConfigUtils.GetRestEndpoint());
        }
    }
}
