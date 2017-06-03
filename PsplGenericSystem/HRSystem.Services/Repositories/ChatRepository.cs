using HRSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Services.Repositories
{
    public class ChatRepository : IChat
    {
        private const string token = "?token=a4252510ed080134f6b70b796fd8f07d";
        private const string ApiUrl = "https://api.groupme.com/v3/";

        public string GetSync(string call)
        {
            string result = "";
            string baseURL = string.Format("{0}{1}", call, token);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiUrl);
                    client.Timeout = TimeSpan.FromMinutes(30);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = new HttpResponseMessage();
                    response = client.GetAsync(baseURL).Result;
                    result = response.IsSuccessStatusCode ? (response.Content.ReadAsStringAsync().Result) : response.IsSuccessStatusCode.ToString();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Net.Http.HttpResponseMessage PostSync(string call, string jsonData)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            string baseURL = string.Format("{0}{1}", call, token);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiUrl);
                    client.Timeout = TimeSpan.FromMinutes(30);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    response = client.PostAsync(baseURL, new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json")).Result;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
