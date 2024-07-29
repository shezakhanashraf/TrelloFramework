using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using TrelloProject.FeatureFile;

namespace TrelloProject.Driver
{
    public class SeleniumDriver
    {

        public static IWebDriver driver;

        public IWebDriver Setup(string browserName, string url)
        {
            driver = Browser(browserName);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            return driver;
        }

        static IWebDriver Browser(string browserName)
        {
            if (browserName.ToLower() == "chrome")
            {
                return new ChromeDriver();
            }
            if (browserName.ToLower() == "firefox")
            {
                return new FirefoxDriver();
            }
            if (browserName.ToLower() == "edge")
            {
                return new EdgeDriver();
            }
            else
            {
                return new ChromeDriver();
            }
        }
    }
}
