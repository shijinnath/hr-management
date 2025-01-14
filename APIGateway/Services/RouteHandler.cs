using APIGateway.Models;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIGateway.Services
{


    public class RouteHandler : IRouteHandler
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;

        public RouteHandler(IDistributedCache cache, IHttpClientFactory httpClientFactory)
        {
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResponse> HandleRoute(string serviceName, string action)
        {
            var cacheKey = $"{serviceName}:{action}";
            var cachedData = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonSerializer.Deserialize<ApiResponse>(cachedData);
            }

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://{serviceName}/{action}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(content);
                await _cache.SetStringAsync(cacheKey, content, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
                return apiResponse;
            }

            return new ApiResponse { Success = false, Message = "Service call failed" };
        }
    }
}
