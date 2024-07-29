using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TrelloProject.Support;
using TrelloProject.PageObject;
using RestSharp;
using TrelloDotNet.Model;


namespace TrelloProject.StepDefinitions
{
    [Binding]
    public class auTestingStepDefinitions
    {
        auUtilities au = new auUtilities();
        CustomizedUtils utils = new CustomizedUtils();
        static string BoardName, Id, BoardId, listId;
        JToken json = null;

        [When(@"Board Title is retrieved using another API call")]
        public void Get_the_board_name_through_au_call()
        {
            json = au.GetRequestForBoard(BoardId);
            Id = json["id"].ToString();
        }

        [Given(@"New board is created using an API call")]
        public void Create_board()
        {
            BoardName = utils.SprintNameGeneration();
            json = au.PostRequestForBoardCreation(BoardName);
            BoardId = json["shortUrl"].ToString().Split('/')[4];
        }

        [Then(@"List named ""([^""]*)"" is created for the board using an API call")]
        public void Create_list(string ListName)
        {
            json = au.PostRequestForListCreation(ListName, Id);
            listId = json["id"].ToString();
        }

        [Then(@"Card named ""([^""]*)"" is added to the list through an API call")]
        public void Create_card(string cardName)
        {
            json = au.PostRequestForCardCreation(cardName, listId);
        }

        [Then(@"Board is deleted via an API call")]
        public void Delete_board()
        {
            au.DeleteRequestForBoardDeletion(BoardId);
        }


        [Then(@"Another member ""([^""]*)"" is invited to the board through an their ""([^""]*)""")]
        public void Invite_Member(string memberName, string emailAddress)
        {
            json = au.GetRequestForMemberInvitation(BoardId, memberName, emailAddress);
        }

        [Then(@"the notification is received by another member")]
        public void Notification_for_Other_Member()
        {
            json = au.GetRequestForNotificationID();
            json = au.GetRequestForNotificationVerification();
        }
    }
}
