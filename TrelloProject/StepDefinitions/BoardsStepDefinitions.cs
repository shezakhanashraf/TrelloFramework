using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TrelloProject.FeatureFile;
using TrelloProject.PageObject;

namespace TrelloProject.StepDefinitions
{
    [Binding]
    public class BoardsStepDefinitions : BoardsPage 
    {
        [Given(@"User is on the Trello Dashboard")]
        public void GivenUserOnTrelloDashboard()
        {
            WorkspacePage();
        }

        [When(@"User creates a new board with ""([^""]*)""")]
        public void WhenUserCreatesANewBoardWithTheTitle(string boardTitle)
        {
            ClickOnCreate();
            ClickOnCreateBoard();
            EnterBoardTitle(boardTitle);
            ClickOnStartTemplate();
        }

        [Then(@"User should see that the board ""([^""]*)"" is successfully created")]
        public void ThenUserShouldSeeThatTheBoardIsSuccessfullyCreated(string boardTitle)
        {
            VerifyBoardCreation(boardTitle);
        }


        [Given(@"User redirects to existing board with title ""([^""]*)""")]
        public void GivenUserRedirectsToExistingBoardWithTitle(string boardTitle)
        {
            ClickBoardButton();
            OpenBoardWithTitle(boardTitle);
        }

        [When(@"User invites ""([^""]*)"" to the board")]
        public void WhenUserInvitesAnotherUserToBoard(string anotherUser)
        {

            ClickShareBtn();
            EnterMemberName("useraccount197");
            SelectMemberFromDropDown(anotherUser);
            EnterInviteMessage();
            ClickShareInviteBtn();
        }

        [Then(@"""([^""]*)"" Name is added on the board")]
        public void ThenMemberIsDisplayedOnTheBoard(string memberName)
        {
            bool isMemberDisplayed = IsMemberDisplayedOnBoard(memberName);
            Assert.AreEqual(true, isMemberDisplayed, $"Member '{memberName}' is not displayed on the board.");
            ClickCancelPopUp();
        }


        [When(@"""(.*)"" checks their notifications")]
        public void WhenInvitedUserChecksNotification(string anotherUser)
        {
            ClickNotificationBtn();
        }

        [Then(@"Request should be present from ""(.*)""")]
        public void ThenRequestMustBePresent(string memberName)
        {
            ClickRequestForMember(memberName);
        }



        [When(@"User chooses to delete the board ""(.*)""")]
        public void WhenUserDeletesTheBoard(string BoardTitle)
        {
            ClickBoardButton();
            OpenBoardWithTitle(BoardTitle);
            ClickMenuBtn();
            //ScrollToBottom(driver);
            ClickCloseBoard();
            ClickCloseBtn();
            ClickPerDeleteBtn();
            ClickDeleteBtn();
        }

        [Then(@"Board should be removed with ""(.*)""")]
        public void ThenBoardShouldBeRemoved(string expectedText)
        {
            GetPopupText();
        }
    }
}
