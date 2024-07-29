using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TrelloProject.Support;

namespace TrelloProject.PageObject
{
    public class LoginPage : BaseMethods
    {
        #region Locators

        public By logInBtn = By.XPath("//a[text()='Log in']");
        public By email = By.Id("username");
        public By cont = By.XPath("//span[text()='Continue']");
        public By password = By.Id("password");
        public By login = By.Id("login-submit");
        public By userProfile = By.XPath("//div[@class='B1uWdim9Jd0dJ9']");
        public By logOut = By.XPath("//span[@class='BmRHtH7FIX0jcL' and text()='Log out']");

        #endregion

        public void InitializeSetup()
        {
            driver = Setup(Utilities.GetValue("browserName"), Utilities.GetValue("applicationUrl"));
        }


        public void ClickOnLogInBtn()
        {
            Click(logInBtn);
        }

        public void ClickOnContinue()
        {
                Click(cont);
        }

        public void EnterUsername(string username)
        {
            SendKeys(email, username);
        }

        public void EnterPassword(string pass)
        {
            SendKeys(password, pass);
        }

        public void ClickOnLogin()
        {
            Click(login);
        }
        public void ClickOnUserProfile()
        {
            Click(userProfile);
        }

        public void ClickOnLogout()
        {
            Click(logOut);
        }
    }
}
