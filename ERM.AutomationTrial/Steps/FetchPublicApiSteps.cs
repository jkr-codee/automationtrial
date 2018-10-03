using System;
using System.Collections.Generic;
using ERM.AutomationTrial.Infrastructure.Entity;
using ERM.AutomationTrial.Infrastructure.Helpers;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using ERM.AutomationTrial.Api;
using ERM.AutomationTrial.Common;
using ERM.AutomationTrial.Infrastructure.Utils;
using ERM.AutomationTrial.Infrastructure;

namespace ERM.AutomationTrial.Steps
{
    [Binding]
    public class FetchPublicApiSteps
    {
        private TypeCodeApi _typeCodeApi;

        [When(@"I have loaded REST Api data")]
        public void WhenIHaveLoadedRESTApiData()
        {
            _typeCodeApi.LoadData();
        }

        [When(@"I check the title of the posts")]
        public void WhenICheckTheTitleOfThePosts(Table table)
        {
            _typeCodeApi.CheckTitleOfPosts(table);
        }

        [When(@"I check the number of records created for each users")]
        public void WhenICheckTheNumberOfRecordsCreatedForEachUsers(Table table)
        {
            _typeCodeApi.CheckNumberOfRecordsForEachUser(table);
        }

        [Then(@"There are no blank values in each fields")]
        public void ThenThereAreNoBlankValuesInEachFields()
        {
            Assert.IsFalse(_typeCodeApi.AreThereAnyBlanks());
        }


        [Then(@"There are no duplicate titles")]
        public void ThereAreNoDuplicateTitles()
        {
            Assert.IsTrue(!_typeCodeApi.AreThereAnyDuplicateTitles());
        }


        [Given(@"The rest endpoint in the config file")]
        public void GivenTheRestEndpointInTheConfigFile()
        {
            _typeCodeApi = new TypeCodeApi();
            _typeCodeApi.SetEndpoint();
        }
        
       
    }
}
