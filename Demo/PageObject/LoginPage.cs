using OpenQA.Selenium;

namespace Demo.PageObject
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver _driver)
        {
            this.driver = _driver;

        }
        #region Elements
        public IWebElement UserName => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement Submit => driver.FindElement(By.Id("login-button"));
        public IWebElement Error => driver.FindElement(By.CssSelector("[data-test='error']"));

        #endregion

        #region Actions
        public void Login(string userName, string password)
        {
            UserName.SendKeys(userName);
            Password.SendKeys(password);
            Submit.Click();

        }
       
        public bool ErrorMessageDisplay()
        {
            return Error.Displayed;

        }

        #endregion

    }
}
