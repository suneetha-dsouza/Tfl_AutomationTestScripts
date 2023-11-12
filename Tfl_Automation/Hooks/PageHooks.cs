using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tfl_Automation.Hooks
{
    [Binding]
    public sealed class PageHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _container;
        private IWebDriver? _webDriver;

        public PageHooks(IObjectContainer container) {

            _container = container;
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _webDriver = new ChromeDriver(Environment.CurrentDirectory);
            //_webDriver = new ChromeDriver(@"C:\Users\pc\Desktop\TFL_SRC\Tfl_Automation\Tfl_Automation\Drivers");
            _webDriver.Navigate().GoToUrl("https://www.tfl.gov.uk/");
            _webDriver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(_webDriver);
            _webDriver.FindElement(By.XPath("//*[@id=\"CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll\"]")).Click();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
