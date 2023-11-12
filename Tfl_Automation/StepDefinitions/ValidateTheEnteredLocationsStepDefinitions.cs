using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using NuGet.Frameworks;
using TechTalk.SpecFlow;
using Tfl_Automation.PageObjects;

namespace Tfl_Automation.StepDefinitions
{
    [Binding]
    public class ValidateTheEnteredLocationsStepDefinitions
    {
        private readonly IWebDriver _webDriver;
        private readonly JourneyPlanner _journeyPlanner;
        private IWebElement? _journeyPlannerResult;
        private readonly JourneyPlannerResultsPage _journeyPlannerResultsPage;

        public ValidateTheEnteredLocationsStepDefinitions(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            _journeyPlanner = new JourneyPlanner(_webDriver);
            _journeyPlannerResultsPage = new JourneyPlannerResultsPage(_webDriver);
        }

        [Given(@"I access the TFL website\.")]
        public void GivenIAccessTheTFLWebsite_()
        {
            //_webDriver.Navigate().GoToUrl("https://www.tfl.gov.uk/");
            //_webDriver.Manage().Window.Maximize();
            //_webDriver.FindElement(By.XPath("//*[@id=\"CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll\"]")).Click();
        }

        [When(@"I enter a valid location as '([^']*)' in From Input field")]
        public void WhenIEnterAValidLocationAsInFromInputField(string location)
        {
            _journeyPlanner.EnterStartLocation(location);
        }

        [When(@"I enter a valid location as '([^']*)' in To Input field")]
        public void WhenIEnterAValidLocationAsInToInputField(string location)
        {
            _journeyPlanner.EnterEndLocation(location);
        }

        [When(@"I click on Plan my Journey button")]
        public void WhenIClickOnPlanMyJourneyButton()
        {
            _journeyPlanner.PlanJourney();
        }

        [Then(@"I should verify the valid journey results in Journey results page")]
        public void ThenIShouldVerifyTheValidJourneyResultsInJourneyResultsPage()
        {
            _journeyPlannerResult = _journeyPlannerResultsPage.ValidateValidJourney();
            //Assert.IsTrue(!string.IsNullOrEmpty(_journeyPlannerResult.Text));
            //Assert.IsTrue(_journeyPlannerResult.Displayed);
        }


        [Then(@"I should see the valid journey results in Journey results page")]
        public void ThenIShouldSeeTheValidJourneyResultsInJourneyResultsPage()
        {
            _journeyPlannerResult = _journeyPlannerResultsPage.ValidateValidJourney();
            // Assert.IsTrue(_journeyPlannerResult.Displayed);
        }

        [When(@"I enter an invalid location as '([^']*)' in From Input field")]
        public void WhenIEnterAnInvalidLocationAsInFromInputField(string location)
        {
            _journeyPlanner.InvalidStartLocation(location);
        }

        [When(@"I enter an invalid location as '([^']*)' in To Input field")]
        public void WhenIEnterAnInvalidLocationAsInToInputField(string location)
        {
            _journeyPlanner.InvalidEndLocation(location);
        }

        [Then(@"I should see a result not found message")]
        public void ThenIShouldSeeAResultNotFoundMessage()
        {
            _journeyPlannerResult = _journeyPlannerResultsPage.ValidateInvalidJourney();
            Assert.IsTrue(_journeyPlannerResult.Displayed, "Error displayed.");
        }

        [When(@"I click on Plan my Journey button without entering From and To location field")]
        public void WhenIClickOnPlanMyJourneyButtonWithoutEnteringFromAndToLocationField()
        {
            _journeyPlanner.PlanJourney();
        }

        [Then(@"I should see an error message ""([^""]*)"" below From field")]
        public void ThenIShouldSeeAnErrorMessageBelowFromField(string errorMessage)
        {
            var actualErrorMessage = _journeyPlanner.ValidateEmptyFromFieldErrorMessage(errorMessage).Text;
            Assert.AreEqual(errorMessage, actualErrorMessage);
        }

        [Then(@"I should see an error message ""([^""]*)"" below To field")]
        public void ThenIShouldSeeAnErrorMessageBelowToField(string errorMessage)
        {
            var actualErrorMessage = _journeyPlanner.ValidateEmptyToFieldErrorMessage(errorMessage).Text;
            Assert.AreEqual(errorMessage, actualErrorMessage);
        }

        [When(@"I click Plan a journey tab link Journey results page")]
        public void WhenIClickPlanAJourneyTabLinkJourneyResultsPage()
        {
            _journeyPlannerResultsPage.ClickOnPlanAJourneyLink();
        }

        [When(@"I click on Recents Tab in Plan a journey Page")]
        public void WhenIClickOnRecentsTabInPlanAJourneyPage()
        {
            _journeyPlanner.RecentTab();
        }

        [Then(@"I see recently planned journey results")]
        public void ThenISeeRecentlyPlannedJourneyResults()
        {
            var recentSearches = _journeyPlannerResultsPage.GetRecentSearchList();
            Assert.That(recentSearches.Count, Is.GreaterThan(0));
        }

        [When(@"I click on Edit journey link in journey results page")]
        public void WhenIClickOnEditJourneyLinkInJourneyResultsPage()
        {
            _journeyPlannerResultsPage.ClickEditJourneyLink();
        }

        [When(@"I Edit the Journey details")]
        public void WhenIEditTheJourneyDetails()
        {
            _journeyPlannerResultsPage.EditJourneyDetailsPage();
        }

        [When(@"I update the changes by clicking Update Journey button")]
        public void WhenIUpdateTheChangesByClickingUpdateJourneyButton()
        {
            _journeyPlannerResultsPage.UpdateJourneyButton();
        }

        [Then(@"I see updated Journey results")]
        public void ThenISeeUpdatedJourneyResults()
        {
            _journeyPlannerResult = _journeyPlannerResultsPage.ValidateValidJourney();

            var Result = _journeyPlanner.ValidateUpdateJourneyResultPage().Text;
            Assert.AreEqual("Arriving:", Result);
        }

        [When(@"I click on change time link")]
        public void WhenIClickOnChangeTimeLink()
        {
            _journeyPlanner.ChangeTimeLink();
        }

        [Then(@"I verify '([^']*)' option displays")]
        public void ThenIVerifyOptionDisplays(string arrivingText)
        {
            string actualText = _journeyPlanner.VerifyArrivingOptionDisplays().Text;
            Assert.AreEqual(actualText, arrivingText);
            _journeyPlanner.ArrivingOptionClick();
        }

        [Then(@"I click on Plan  my Journey button")]
        public void ThenIClickOnPlanMyJourneyButton()
        {
            _journeyPlanner.PlanJourney();
        }
    }
}
