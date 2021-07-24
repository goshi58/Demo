using OpenQA.Selenium;

namespace Demo.PageObject
{
    public class CheckOutPage
    {
        private IWebDriver driver;

        public CheckOutPage(IWebDriver _driver)
        {
            this.driver = _driver;

        }
        #region Elements
        public IWebElement FirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement LastName => driver.FindElement(By.Id("last-name"));
        public IWebElement Zip => driver.FindElement(By.Id("postal-code"));
        public IWebElement Continue => driver.FindElement(By.Id("continue"));

        

        #endregion

        #region Actions

        public void FillCheckoutInformation(string firstName , string lastName , string zip) 
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Zip.SendKeys(zip);
            Continue.Click();
        }

        #endregion

    }
}
