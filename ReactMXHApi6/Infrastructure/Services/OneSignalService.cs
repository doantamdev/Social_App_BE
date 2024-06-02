using ReactMXHApi6.Core.Interfaces;
using ReactMXHApi6.Dtos;
using RestSharp;
using System.Text.Json;

namespace ReactMXHApi6.Infrastructure.Services
{
    public class OneSignalService : IOneSignalService
    {
        private readonly IConfiguration _config;
        public OneSignalService(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Sends notifications to your users
        /// </summary>
        /// <param name="body">include_subscription_ids = string[], contents: object, name = INTERNAL_CAMPAIGN_NAME </param>
        /// <returns>ResultOneSignal</returns>
        public async Task<ResultOneSignal> CreateNotification(object body)
        {
            var json = JsonSerializer.Serialize(body);
            var options = new RestClientOptions("https://onesignal.com/api/v1/notifications");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Basic {_config["OneSignal:RestAPI"]}");
            request.AddJsonBody(json, false);
            var response = await client.PostAsync(request);
            Console.WriteLine("{0}", response.Content);
            return new ResultOneSignal((int)response.StatusCode, response.Content!);
        }
    }
}
