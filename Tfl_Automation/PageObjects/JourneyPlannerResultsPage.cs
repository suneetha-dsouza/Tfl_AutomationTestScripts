using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Numerics;

namespace Tfl_Automation.PageObjects
{
    public class JourneyPlannerResultsPage
    {

        private readonly WebDriverWait? _webDriverWait;

        public JourneyPlannerResultsPage(IWebDriver webDriver)
        {
            _webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(45));
        }

        public IWebElement ValidateValidJourney()
        {
            // return _webDriverWait!.Until(driver => driver.FindElement(By.XPath("(//div[@class='clearfix time-boxes time-boxes-override'])[1]")));
            return _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//*[@id=\"option-1-heading\"]")));
        }

        public IWebElement ValidateInvalidJourney()
        {
            //*[@id="full-width-content"]/div/div[8]/div/div/ul
            return _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//*[@id=\"full-width-content\"]/div/div[8]/div/div/ul")));
        }

        public void ClickOnPlanAJourneyLink()
        {
            Thread.Sleep(2000);
            _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//*[@id=\"full-width-content\"]/div/div[1]/div/ol/li[2]/a"))).Click();

        }

        public void ClickEditJourneyLink()
        {
            Thread.Sleep(1000);
            _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//span[contains(text(), 'Edit journey')]"))).Click();
        }

        public void EditJourneyDetailsPage()
        {
            _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//label[contains(@for,'arriving')]"))).Click();
        }

        public void UpdateJourneyButton()
        {
            _webDriverWait!.Until(driver => driver.FindElement(By.XPath("//input[contains(@id,'plan-journey-button')]"))).Click();
        }

        public List<IWebElement> GetRecentSearchList()
        {
            return _webDriverWait!.Until(driver => driver.FindElements(By.XPath("//*[@id=\"jp-recent-content-jp-\"]")).ToList());
        }
    }
}
