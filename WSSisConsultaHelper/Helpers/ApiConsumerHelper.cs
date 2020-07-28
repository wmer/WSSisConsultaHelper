using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WSSisConsultaHelper.Helpers {
    public class ApiConsumerHelper {
        private HttpClient _client;

        public ApiConsumerHelper(string baseAdress) {
            _client = new HttpClient() {
                BaseAddress = new Uri(baseAdress)
            };
            var mediaType = new MediaTypeWithQualityHeaderValue("application/xml");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
            _client.Timeout = TimeSpan.FromMinutes(3);
        }

        public (T result, string statusCode, string message) Get<T>(string endPoint) {
            return GetAssync<T>(endPoint).Result;
        } 

        public async Task<(T result, string statusCode, string message)> GetAssync<T>(string endPoint) {
            var response = await _client.GetAsync($"{_client.BaseAddress}{endPoint}");
            return DeserializeResponse<T>(response);
        }



        public (T result, string statusCode, string message) DeserializeResponse<T>(HttpResponseMessage response) {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var statusCode = response.StatusCode.ToString();
            try {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseContent);

                string json = JsonConvert.SerializeXmlNode(doc);

                if (response.IsSuccessStatusCode) {
                    return (JsonConvert.DeserializeObject<T>(json), statusCode, json);
                } else {
                    return (default(T), statusCode, responseContent);
                }
            } catch (Exception e) {
                return (default(T), statusCode, responseContent);
            }

        }
    }
}
