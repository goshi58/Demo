using OpenQA.Selenium;

namespace Demo.PageObject
{
    public class OverviewPage
    {
        private IWebDriver driver;

        public OverviewPage(IWebDriver _driver)
        {
            this.driver = _driver;

        }
        #region Elements
        public IWebElement Finish => driver.FindElement(By.Id("finish"));

        #endregion

        #region Actions

        public void FinishOverview()
        {
            Finish.Click();
        }

        #endregion
    }
}
