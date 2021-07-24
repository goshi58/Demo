using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Demo.PageObject
{
    public class BaseClass
    {
        public static IWebDriver driver = null;
        public static IConfiguration config;

        public BaseClass()
        {
            config = InitConfiguration();
        }

        public void Initialize(string browser)
        {
            switch (browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;

                case "chrome":
                    driver = new ChromeDriver();
                    break;

                case "IE":
                    driver = new InternetExplorerDriver();
                    break;

            }

            driver.Navigate().GoToUrl(config["URL"]);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

        }

        public void Quit()
        {
            driver.Close();
            driver.Quit();

        }

        public IConfiguration InitConfiguration()
        {
            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;

        }

    }
}
