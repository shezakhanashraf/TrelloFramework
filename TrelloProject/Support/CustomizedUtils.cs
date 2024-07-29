using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace TrelloProject.Support
{
    public class CustomizedUtils
    {
        public CustomizedUtils()
        {
        }

        public void DragAndDrop(IWebElement from, IWebElement to, IWebDriver driver)
        {
            Actions act = new Actions(driver);
            act.DragAndDrop(from, to).Build().Perform();
        }

        public string SprintNameGeneration()
        {
            Random rnd = new Random();
            int num = rnd.Next(10, 100);
            string name = "Sprint " + num.ToString();
            return name;
        }

        public void CreateList(IWebDriver driver)
        {
            try
            {
                if (driver.FindElement(By.XPath("//h2[contains(text(),'Doing')]")).Displayed)
                {
                    // Element is displayed, do something
                }
            }
            catch (NoSuchElementException)
            {
                // Element is not displayed, perform actions to create list
                IWebElement inputDoing = driver.FindElement(By.XPath("//input[@placeholder='Enter list title…']"));
                inputDoing.SendKeys("Doing");
                driver.FindElement(By.XPath("//input[@value='Add list']")).Click();
                IWebElement inputDone = driver.FindElement(By.XPath("//input[@placeholder='Enter list title…']"));
                inputDone.SendKeys("Done");
                driver.FindElement(By.XPath("//input[@value='Add list']")).Click();
            }
        }
    }
}
