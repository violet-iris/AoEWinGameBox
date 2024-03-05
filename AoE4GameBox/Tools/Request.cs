using AoE4GameBox.Common;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AoE4GameBox.Tools
{
    public class Request
    {
        public static async Task<Result> RequestURL(string url)
        {
            Logger.Info("Try Calling RequestURL", url);
            try
            {
                using HttpClient client = new();
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Logger.Info($"Request successful with status code: {response.StatusCode}");
                    return Result.Success(responseBody);
                } else
                {
                    Logger.Info($"Request failed with status code: {response.StatusCode}");
                    return Result.Error("Request failed");
                }
            } catch (Exception ex)
            {
                Logger.Error($"Exception: {ex}");
                return Result.Error("Request error");
            }
        }
    }
}
