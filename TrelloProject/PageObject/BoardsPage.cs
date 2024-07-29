using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenQA.Selenium;
using TrelloProject.FeatureFile;
using TrelloProject.Support;

namespace TrelloProject.PageObject
{
    public class BoardsPage : BaseMethods
    {

        #region Locators

        public By createBtn = By.XPath("//p[text()='Create']");
        public By createBoard = By.XPath("//span[text()='Create board']");
        public By boardTitle = By.XPath("//input[@data-testid=\"create-board-title-input\"]");
        public By createTemplate = By.XPath("//button[text()=\"Create\"]");
        public By createdBoardTitle = By.XPath("//h1[@class='HKTtBLwDyErB_o']");
        public By boardsBtn = By.XPath("//span[@class='DD3DlImSMT6fgc XQSLFE3ZZrvms3' and text()='Boards']");
        public string GetBoardTitleXPath(string boardTitle)
        {
            return $"//div[@class='board-tile-details-name']/div[text()='{boardTitle}']";
            
        }
        public By shareBoardBtn = By.XPath("//button[@title='Share board']");
        public By memberEmailTxt = By.XPath("//input[@data-testid='add-members-input']");
        public string GetMemberNameXPath(string memberName) //member name from dropdown
        {
            return $"//div[@class='CYC1t6y1xBAjCz S63MQ7i2dm44jv' and text()='{memberName}']";

        }
        public By inviteMessage = By.XPath("//textarea[@data-testid='custom-invitation-message-input']");
        public By shareBtn = By.XPath("//button[contains(@title, 'Share board')]");
        public string GetInvitedMemberNameXPath(string memberName)
        {
            return $"//span[@data-testid='member-list-item-full-name' and text()='{memberName}']";
        }

        public By shareInviteBtn = By.XPath("//button[@data-testid = 'team-invite-submit-button']");
        public By notificationBtn = By.XPath("//button[@data-testid='header-notifications-button']");
        public string GenerateXPathForMember(string memberName)
        {
            return $"//strong[@class='_KTqPSXUStsQsF' and text()='{memberName}']" +
                   $"/ancestor::div[@class='T1ZrA08Vkawjhe cDizybVFxB0gJw jZjd7mo5nSzvu8']" +
                   $"//following-sibling::div/div[@class='vFrn5UktIxZYaj' and text()='Added you to the board ']/a";
        }

        public By menu = By.XPath("//button[@aria-label='Show menu']");
        public By closeBoard = By.XPath("//a[@class='board-menu-navigation-item-link board-menu-navigation-item-link-v2 js-close-board']");
        public By closeBtn = By.XPath("//input[@value='Close']");
        public By permanentlyDelBtn = By.XPath("//button[@data-testid='close-board-delete-board-button']");
        public By deleteBtn = By.XPath("//button[text()='Delete']");
        public By boardDeletedTxt = By.XPath("//span[text()='Board deleted.']");
        public By cancelPopUp = By.XPath("//span[@data-testid='CloseIcon']");


        #endregion

        public void WorkspacePage()
        {
            FindTextOnPage("YOUR WORKSPACES");
        }
        public void ClickOnCreate()
        {
            Click(createBtn);
        }

        public void ClickOnCreateBoard()
        {
            Click(createBoard);
        }

        public void EnterBoardTitle(string title)
        {
            SendKeys(boardTitle, title);
        }

        public void ClickOnStartTemplate()
        {
            Click(createTemplate);
        }

        public void VerifyBoardCreation(string title) 
        {
            WaitForElementVisible(createdBoardTitle);
            VerifyText(createdBoardTitle, title);
        }

        public void ClickBoardButton()
        {
            WaitForElementClickable(boardsBtn);
            Click(boardsBtn);
        }

        public void OpenBoardWithTitle(string boardTitle)
        {

            string boardXPath = GetBoardTitleXPath(boardTitle);
            if (boardXPath != null)
            {
                By boardLocator = By.XPath(boardXPath);
                WaitForElementClickable(boardLocator);
                Click(boardLocator); 
            }
            else
            {
                throw new Exception($"XPath for board with title '{boardTitle}' was not found.");
            }
        }

        public void ClickShareUser()
        {
            Click(shareBoardBtn);
        }

        public void EnterMemberName(string name)
        {
            SendKeys(memberEmailTxt, name);
        }


        public void SelectMemberFromDropDown(string memberName)
        {
            string memberXPath = GetMemberNameXPath(memberName);
            if (memberXPath != null)
            {
                By memberLocator = By.XPath(memberXPath);
                Click(memberLocator);
            }
            else
            {
                throw new Exception($"XPath for '{memberName}' was not found.");
            }
        }

        public void EnterInviteMessage()
        {
            SendKeys(inviteMessage, "I'm inviting you to join our Trello team, where we manage projects with ease and efficiency.");
        }

        public void ClickShareBtn()
        {
            Click(shareBtn);
        }

        public void ClickShareInviteBtn()
        {
            Click(shareInviteBtn);
        }

        public bool IsMemberDisplayedOnBoard(string memberName)
        {
            string memberXPath = GetInvitedMemberNameXPath(memberName);
            Thread.Sleep(10000);
            return IsElementDisplayed(By.XPath(memberXPath));
        }

        public void ClickCancelPopUp()
        {
            Click(cancelPopUp);
        }

        public void ClickNotificationBtn()
        {
            Click(notificationBtn);
        }

        public void ClickRequestForMember(string memberName)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                throw new ArgumentNullException(nameof(memberName), "Member name cannot be null or empty.");
            }

            string dynamicXPath = GenerateXPathForMember(memberName);

            if (string.IsNullOrEmpty(dynamicXPath))
            {
                throw new Exception($"Generated XPath for member '{memberName}' is null or empty.");
            }

            Click(By.XPath(dynamicXPath));
        }
        public void ClickMenuBtn()
        {
            WaitForElementClickable(menu);
            Click(menu);
        }

        public void ClickCloseBoard()
        {
            Click(closeBoard);
        }

        public void ClickCloseBtn()
        {
            Click(closeBtn);
        }

        public void ClickPerDeleteBtn()
        {
            Click(permanentlyDelBtn);
        }

        public void ClickDeleteBtn()
        {
            Click(deleteBtn);
        }

        public void GetPopupText()
        {
            GetTextFromPopup();
        }
    }

}

