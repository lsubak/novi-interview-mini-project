using Newtonsoft.Json.Linq;
using NoviInterviewMiniProject.Models;
using NoviInterviewMiniProject.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NoviInterviewMiniProject.Repositories
{
    public interface INoviApiCaller
    {
        List<Member> GetData();
    }

    public class NoviApiCaller : INoviApiCaller
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly IGlobalSettings _globalSettings;

        public NoviApiCaller(IGlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _globalSettings.ApiKey);
        }

        public List<Member> GetData()
        {
            var data = new List<Member>();

            string responseBody = _client.GetStringAsync($"{_globalSettings.ApiUrl}/members").Result;

            var responseJson = JObject.Parse(responseBody);

            data = responseJson.SelectToken("Results").ToObject<List<Member>>();

            return data;
        }
    }
}