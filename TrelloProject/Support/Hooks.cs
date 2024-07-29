using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TrelloProject.PageObject;

namespace TrelloProject.Support
{
    [Binding]
    public sealed class Hooks : LoginPage
    {

        [BeforeScenario]
        public void BeforeScenario()
        {
            InitializeSetup();
            ClickOnLogInBtn();
            EnterUsername(Utilities.GetValue("userOneUsername"));
            ClickOnContinue();
            EnterPassword(Utilities.GetValue("userOnePassword"));
            ClickOnLogin();
        }

       [BeforeScenario("@SecondUserCase")]
        public void BeforeScenarioForSecondUser()
        {
            InitializeSetup();
            ClickOnLogInBtn();
            EnterUsername(Utilities.GetValue("userTwoUsername"));
            ClickOnContinue();
            EnterPassword(Utilities.GetValue("userTwoPassword"));
            ClickOnLogin();
        }

       [AfterScenario]
        public void AfterScenario()
        {
            // Add logout steps here if needed
            ClickOnUserProfile();
            ClickOnLogout();
            driver.Quit();
        }
    }
}
