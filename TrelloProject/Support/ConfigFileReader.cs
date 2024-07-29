using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;
using Json;

namespace TrelloProject.Support
{

    public class ConfigFileReader
    {
        private readonly string propertyFilePath = "Support/applicationData.json";
        private JObject configFile;

        public ConfigFileReader()
        {
            try
            {
                // Load the JSON configuration file
                string jsonContent = File.ReadAllText(propertyFilePath);
                configFile = JObject.Parse(jsonContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string GetURL()
        {
            return GetValueFromConfig("applicationUrl");
        }

        public string GetEmailID()
        {
            return GetValueFromConfig("userOneUsername");
        }

        public string GetPassword()
        {
            return GetValueFromConfig("userOnePassword");
        }

        public string GetBoardBaseURL()
        {
            return GetValueFromConfig("BOARD_BASE_URL");
        }

        public string GetCreateListURL()
        {
            return GetValueFromConfig("CREATE_LIST_URL");
        }

        public string GetCreateCardURL()
        {
            return GetValueFromConfig("CREATE_CARD_URL");
        }

        public string GetAPIKey()
        {
            return GetValueFromConfig("API_KEY");
        }

        public string GetToken()
        {
            return GetValueFromConfig("TOKEN");
        }

        public string GetAPIKeyForTrello()
        {
            return GetValueFromConfig("API_KEY_TRELLO");
        }

        public string GetTokenForTrello()
        {
            return GetValueFromConfig("TOKEN_TRELLO");
        }

        public string GetBrowser()
        {
            return GetValueFromConfig("browserName");
        }

        public string GetNotificationID()
        {
            return GetValueFromConfig("NOTIFICATION_URL");
        }

        public string GetNotificationURL()
        {
            return GetValueFromConfig("NOTIFICATION_ID_URL");
        }

        private string GetValueFromConfig(string key)
        {
            try
            {
                string[] keys = key.Split(':');
                JToken value = configFile;

                foreach (string k in keys)
                {
                    value = value[k];
                }

                return value?.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error retrieving value for key '{key}': {e.Message}");
                return null;
            }
        }

    }
}
