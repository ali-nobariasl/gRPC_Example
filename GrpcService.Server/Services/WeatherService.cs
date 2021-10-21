using Grpc.Core;
using GrpcService.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static GrpcService.Server.Protos.WeatherService;

namespace GrpcService.Server.Services
{
    public class WeatherService : WeatherServiceBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public override Task<WeatherResponse> GetCurrentWeather(
            GetCurrentWeatherForCityRequest request, ServerCallContext context)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var responseText= httpClient.GetStringAsync(
                $"http://api.openweathermap.org/data/2.5/weather?q={request.City}&appid=07502ba820841f05edd5b80940f9527d&units={request.Units}") ;
            return null;
        }
    }
}
