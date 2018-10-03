using System;
using TechTalk.SpecFlow;

namespace ERM.AutomationTrial.Common
{
    /// <summary>
    /// Specflow hooks for logging using log4net
    /// </summary>
    [Binding]
    public class Hooks 
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [BeforeScenario()]
        public void BeforeScenario()
        {
            ScenarioContext.Current["scenarioStartTime"] = DateTime.Now;
            _log.Info($"Scenario start time {DateTime.Now}");
        }


        [AfterScenario]
        public void AfterScenario()
        {
            var startTime = (DateTime)ScenarioContext.Current["scenarioStartTime"];
            var currentTime = DateTime.Now;
            _log.Info($"Time taken to complete the Test is {currentTime.Subtract(startTime).Seconds} seconds.");
        }


        [BeforeFeature()]
        public static void BeforeFeature()
        {
            FeatureContext.Current["featureStartTime"] = DateTime.Now;
            _log.Info($"Feature start time {DateTime.Now}");
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            var startTime = (DateTime)ScenarioContext.Current["scenarioStartTime"];
            var currentTime = DateTime.Now;
            _log.Info($"Time taken to complete the feature testing is {currentTime.Subtract(startTime).Seconds} seconds.");
        }
    }
}
