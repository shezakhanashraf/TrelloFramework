using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TrelloProject.PageObject;

namespace TrelloProject.Support
{
    public static class Utilities
    {
        private static JObject appConfig;

        static Utilities()
        {
            LoadAppConfig();
        }

        public static void LoadAppConfig()
        {
            try
            {
                string file = AppDomain.CurrentDomain.BaseDirectory + "Support\\" + "applicationData.json";
                string json = File.ReadAllText(file);
                appConfig = JObject.Parse(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading applicationData.json: " + ex.Message);
                appConfig = null;
            }
        }

        public static string GetValue(string key)
        {
            if (appConfig == null)
            {
                Console.WriteLine("App config not loaded.");
                return null;
            }

            return appConfig[key]?.ToString();
        }
    }
}
