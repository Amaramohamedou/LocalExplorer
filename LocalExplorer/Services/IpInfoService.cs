using System;
using LocalExplorer.Models;
using Newtonsoft.Json;

namespace LocalExplorer.Services
{
    public class IpInfoService
    {
        private readonly HttpClient _httpClient;

        public IpInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IpInfoResponse> GetIpInfoAsync()
        {
            var response = await _httpClient.GetStringAsync("https://ipinfo.io/json?token=ef6f5f2d17fc87");
            return JsonConvert.DeserializeObject<IpInfoResponse>(response);
        }
    }

}

