using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using TrelloProject.Driver;
using System.Globalization;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace TrelloProject.Support
{
    public class BaseMethods : SeleniumDriver
    {

        public void SendKeys(By locator, string value)
        {
            try
            {
                WaitForElementVisible(locator);
                driver.FindElement(locator).SendKeys(value);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Element with locator '{locator}' not found: {ex.Message}");
            }
        }

        public void Click(By locator)
        {
            try
            {
                WaitForElementClickable(locator);
                driver.FindElement(locator).Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Element with locator '{locator}' not found: {ex.Message}");
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"Timeout waiting for element with locator '{locator}': {ex.Message}");
            }
        }

        public void WaitForElementVisible(By locator, int timeoutInSeconds = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                wait.Until(d =>
                {
                    try
                    {
                        var element = d.FindElement(locator);
                        return element.Displayed && element.Enabled;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"Timeout waiting for element with locator '{locator}' to be visible: {ex.Message}");
            }
        }

        public void WaitForElementClickable(By locator, int timeoutInSeconds = 85)
        {
            // Check if the driver object is null
            if (driver == null)
            {
                Console.WriteLine("Error: WebDriver object is null.");
                return;
            }

            // Check if the locator is null
            if (locator == null)
            {
                Console.WriteLine("Error: Locator is null.");
                return;
            }

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

                // Wait until the element is clickable
                wait.Until(d =>
                {
                    try
                    {
                        var element = d.FindElement(locator);
                        return element.Displayed && element.Enabled;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"Timeout waiting for element with locator '{locator}' to be clickable: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while waiting for element with locator '{locator}' to be clickable: {ex.Message}");
            }
        }

        public void ScrollToBottom(IWebDriver driver)
        {
            try
            {
                var jsExecutor = (IJavaScriptExecutor)driver;
                jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Failed to scroll to bottom: {ex.Message}");
            }
        }

        public void OpenUrlInNewTab(string secondURL)
        {
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles[^1]);
                driver.Navigate().GoToUrl(secondURL);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Failed to open URL in new tab: {ex.Message}");
            }
        }

        public void GetValueByTextInDropDown(string locator, string value)
        {
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id(locator)));
            dropDown.SelectByValue(value);
        }

        public bool VerifyText(By locator, string expectedText)
        {
            IWebElement element = driver.FindElement(locator);
            string actualText = element.Text.Trim();
            return actualText.Equals(expectedText);
        }

        public bool FindTextOnPage(string expectedText)
        {
            // Check if the 'driver' object is not null
            if (driver == null)
            {
                Console.WriteLine("Error: WebDriver object is null.");
                return false;
            }

            try
            {
                // Wait for the page to load
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

                // Find all elements containing text in the body
                IReadOnlyList<IWebElement> textElements = driver.FindElements(By.XPath("//body//*[text()]"));

                // Iterate through the text elements
                foreach (IWebElement element in textElements)
                {
                    // Check if the element is displayed and contains the expected text
                    if (element.Displayed && element.Text.Contains(expectedText))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error finding text on page: " + ex.Message);
            }

            // If the expected text is not found or an exception occurs, return false
            return false;
        }

        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetTextFromPopup()
        {
            try
            {
                // Check if alert is present
                IAlert alert = driver.SwitchTo().Alert();

                // Dismiss the alert to handle it
                alert.Dismiss();

                // Return "true" if alert is present
                return "true";
            }
            catch (NoAlertPresentException)
            {
                // Return "false" if no alert is present
                return "false";
            }

        }

        public void CloseDriver()
        {
            driver.Close();
        }
    }
}
