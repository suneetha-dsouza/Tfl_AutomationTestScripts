using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tfl_Automation.PageObjects
{
    public class JourneyPlanner
    {
        private readonly IWebDriver? _webDriver;
        private readonly WebDriverWait? _webDriverWait;

        public JourneyPlanner(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(45));
        }

        private IWebElement BeginStation => _webDriver!.FindElement(By.XPath("//*[@id=\"InputFrom\"]"));
        private IWebElement EndStation => _webDriver!.FindElement(By.XPath("//*[@id=\"InputTo\"]"));
        private IWebElement PlanJourneyButton => _webDriver!.FindElement(By.XPath("//*[@id=\"plan-journey-button\"]"));

        public void EnterStartLocation(string location)
        {
            BeginStation.Clear();
            BeginStation.SendKeys(location);
            var resultList = _webDriverWait!.Until(driver => driver.FindElement(By.XPath("(//span[contains(@class,'stop-name')])[1]")));
            resultList.Click();
        }
        public void EnterEndLocation(string location)
        {
            EndStation.Clear();
            EndStation.SendKeys(location);
            var resultList = _webDriverWait!.Until(driver => driver.FindElement(By.XPath("(//span[contains(@class,'stop-name')])[1]")));
            resultList.Click();
        }
        public JourneyPlannerResultsPage PlanJourney()
        {
            PlanJourneyButton.Click();
            return new JourneyPlannerResultsPage(_webDriver!);
        }

        public void InvalidStartLocation(string location)
        {
            BeginStation.Clear();
            BeginStation.SendKeys(location);
        }
        public void InvalidEndLocation(string location)
        {
            EndStation.Clear();
            EndStation.SendKeys(location);
        }

        public IWebElement ValidateValidJourney()
        {
            return _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//div[@id = 'option-1-heading']")));
        }

        public IWebElement ValidateInvalidJourney()
        {
            return _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//*[@id=\"full-width-content\"]/div/div[8]/div/div/ul")));
        }

        public IWebElement ValidateEmptyFromFieldErrorMessage(string errorMessage)
        {
            return _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//span[@data-valmsg-for = 'InputFrom']/child::span")));
        }

        public IWebElement ValidateEmptyToFieldErrorMessage(string errorMessage)
        {
            return _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//span[@data-valmsg-for = 'InputTo']/child::span")));
        }

        public IWebElement ValidateUpdateJourneyResultPage()
        {
            return _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//span[@class='label'][contains(.,'Arriving:')]")));
        }

        public void ChangeTimeLink()
        {
            _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//a[@href='javascript:void(0)'][contains(.,'change time')]"))).Click();
        }

        public IWebElement VerifyArrivingOptionDisplays()
        {
            return _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//label[@for='arriving'][contains(.,'Arriving')]")));
        }

        public void ArrivingOptionClick()
        {
            _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//label[@for='arriving'][contains(.,'Arriving')]"))).Click();
        }

        public void RecentTab()
        {
            _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//a[@href='#jp-recent'][contains(.,'Recents')]"))).Click();
        }
    }
}
