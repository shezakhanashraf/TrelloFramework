using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace TrelloProject.Support
{
    public class auUtilities
    {
        private ConfigFileReader config = null;
        private string memberId;
        private string type;

        public JObject GetRequestForBoard(string BoardName)
        {
            config = new ConfigFileReader();
            string EndpointURL = config.GetBoardBaseURL() + BoardName;
            RestClient client = new RestClient(EndpointURL);
            RestRequest request = new RestRequest(Method.GET);
            request.AddQueryParameter("key", config.GetAPIKey());
            request.AddQueryParameter("token", config.GetToken());
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            return JObject.Parse(response.Content);
        }

        public JObject PostRequestForBoardCreation(string BoardName)
        {
            config = new ConfigFileReader();
            string EndpointURL = config.GetBoardBaseURL();
            RestClient client = new RestClient(EndpointURL);
            RestRequest request = new RestRequest(Method.POST);
            request.AddQueryParameter("name", BoardName);
            request.AddQueryParameter("key", config.GetAPIKey());
            request.AddQueryParameter("token", config.GetToken());
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            return JObject.Parse(response.Content);
        }

        public JObject PostRequestForListCreation(string ListName, string BoardID)
        {
            config = new ConfigFileReader();
            string EndpointURL = config.GetCreateListURL();
            RestClient client = new RestClient(EndpointURL);
            RestRequest request = new RestRequest(Method.POST);
            request.AddQueryParameter("name", ListName);
            request.AddQueryParameter("idBoard", BoardID);
            request.AddQueryParameter("key", config.GetAPIKey());
            request.AddQueryParameter("token", config.GetToken());
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            return JObject.Parse(response.Content);
        }

        public JObject PostRequestForCardCreation(string CardName, string ListId)
        {
            config = new ConfigFileReader();
            JObject requestParams = new JObject();
            requestParams["name"] = CardName;
            string EndpointURL = config.GetCreateCardURL();
            RestClient client = new RestClient(EndpointURL);
            RestRequest request = new RestRequest(Method.POST);
            request.AddQueryParameter("idList", ListId);
            request.AddQueryParameter("key", config.GetAPIKey());
            request.AddQueryParameter("token", config.GetToken());
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(requestParams.ToString());
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            return JObject.Parse(response.Content);
        }

        public void DeleteRequestForBoardDeletion(string BoardName)
        {
            config = new ConfigFileReader();
            string EndpointURL = config.GetBoardBaseURL() + BoardName;
            RestClient client = new RestClient(EndpointURL);
            RestRequest request = new RestRequest(Method.DELETE);
            request.AddQueryParameter("key", config.GetAPIKey());
            request.AddQueryParameter("token", config.GetToken());
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }


        public JObject GetRequestForMemberInvitation(string BoardName, string MemberName, string EmailAddress)
        {
            config = new ConfigFileReader();
            string EndpointURL = config.GetBoardBaseURL() + BoardName + "/members/?email=" + EmailAddress;
            RestClient client = new RestClient(EndpointURL);
            RestRequest request = new RestRequest(Method.PUT);
            request.AddQueryParameter("key", config.GetAPIKey());
            request.AddQueryParameter("token", config.GetToken());
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            return JObject.Parse(response.Content);
        }


        public JObject GetRequestForNotificationID()
        {
            config = new ConfigFileReader();
            string EndpointURL = config.GetNotificationURL();
            RestClient client = new RestClient(EndpointURL);
            RestRequest request = new RestRequest(Method.GET);
            request.AddQueryParameter("key", config.GetAPIKeyForTrello());
            request.AddQueryParameter("token", config.GetTokenForTrello());
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);


            JArray jsonResponse = JArray.Parse(response.Content);

            foreach (JObject obj in jsonResponse.Children<JObject>())
            {
                JArray notifications = (JArray)obj["notifications"];

                foreach (JObject notification in notifications.Children<JObject>())
                {
                    memberId = notification["id"].ToString();
                    type = notification["type"].ToString();

                    // Assuming you want to assert the type equals "addedToBoard"
                    Assert.AreEqual("addedToBoard", type);

                    // You can return the first valid notification found, if needed
                    return notification;
                }
            }
                return JObject.Parse(response.Content);
        }

            public JObject GetRequestForNotificationVerification()
            {
                config = new ConfigFileReader();
                string EndpointURL = config.GetNotificationID() + memberId;
                RestClient client = new RestClient(EndpointURL);
                RestRequest request = new RestRequest(Method.GET);
                request.AddQueryParameter("key", config.GetAPIKeyForTrello());
                request.AddQueryParameter("token", config.GetTokenForTrello());
                IRestResponse response = client.Execute(request);
                Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
                JObject jsonResponse = JObject.Parse(response.Content);
                string type = jsonResponse["type"].ToString();
                Assert.AreEqual("addedToBoard", type);
                return JObject.Parse(response.Content);
            }
        }
    }
