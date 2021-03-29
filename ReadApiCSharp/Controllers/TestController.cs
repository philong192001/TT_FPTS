using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReadApiCSharp.Models;

namespace ReadApiCSharp.Controllers
{
    public class TestController : Controller
    {
        
        private const string _appID = "bc6da08b-3ad4-4452-8f29-d56bc69e31995";
        private const string _apiKey = "5G2Zix5YcWLdatLFrr+81d7ldMV7Yt5CGftGF5VTqhM=8";
        private const string _accountID = "64857311-d116-4c38-b0ab-1643050c441d";
        private const string _playbackUrl = "https://mam.tek4tv.vn/";
        public async Task<IActionResult> Index()
        {
            string policyKey = "";
            using (var httpClient = new HttpClient())
            {
                policyKey = await getToken();

                List<PlaylistViewModel> playList = new List<PlaylistViewModel>();

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", policyKey);

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url = _playbackUrl + "api/app/playlist/parent/2014";


                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        playList = JsonConvert.DeserializeObject<List<PlaylistViewModel>>(data);
                        ViewBag.playList = playList;
                    }
                }
            }
            return View();

        }

        private async Task<string> getToken()
        {
            string apiResponse = "";
            try
            {
                var token = new
                {
                    AppID = _appID,
                    ApiKey = _apiKey,
                    AccountId = _accountID
                };
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(token), Encoding.UTF8, "application/json");
                    string urlToken = _playbackUrl + "api/token";
                    using (var response = await httpClient.PostAsync(urlToken, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            apiResponse = await response.Content.ReadAsAsync<string>();
                        }
                        else
                        {
                            apiResponse = "No Data";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return apiResponse;
        }
    }
}
