using System;
using Be.Cadmus.Dotnetconnector.Model;
using Be.Cadmus.Dotnetconnector.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Be.Cadmus.Dotnetconnector {

    public class Convertor {
        
        internal static string pdfButlerUrl = "https://www.pdfbutler.com";
        private static HttpClient _client = null;
        private static Boolean credentialsDirty = true;
        private static string _username { get; set; }
        public static string Username
        {
            get { return _username; }
            set { _username = value;credentialsDirty = true; }
        }
        private static string _password { get; set; }
        public static string Password
        {
            get { return _password; }
            set { _password = value;credentialsDirty = true; }
        }

        private static HttpClient GetClient() {
            if(_client == null) {
                _client = new HttpClient();
                _client.BaseAddress = new Uri(pdfButlerUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            return _client;
        }

        private static string createBearer(String username, String password) {
            //create base64
            //use USER type of username
            
            String authString = username + Constants.ROLE_SEPERATOR + Constants.UserRole.USER.ToString() + ":" + password;
            //Console.WriteLine("authString: " + authString);
            string ret = Convert.ToBase64String(Encoding.ASCII.GetBytes(authString));
            //Console.WriteLine("bearer: " + ret);
            return ret;
        }

        public static string GetPdfButlerUrl() {
            return pdfButlerUrl;
        }

        public static void SetPdfButlerUrl(String pdfButlerUrlIn) {
            pdfButlerUrl = pdfButlerUrlIn;
        }

        
        public static ConvertResponse DoConvert(Metadata metadata, Datasources datasources, String docConfigId) {

            HttpClient client = GetClient();
            
            if(credentialsDirty) {
                client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + createBearer(Username, Password));
                Console.WriteLine("Authorization header set");
                credentialsDirty = false;
            }

            ConvertData convertData = new ConvertData();
            convertData.metadata = metadata;
            convertData.dataSources = datasources.GetAsString();
            convertData.customerDocumentConfigId = docConfigId;

            string body = JsonConvert.SerializeObject(convertData);
            //Console.WriteLine("body: " + body);

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/convert", content).Result;
            
            if(response.IsSuccessStatusCode) {
                string strResponse = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine("convert Response: " + strResponse);
                ConvertResponse result = JsonConvert.DeserializeObject<ConvertResponse>(strResponse);
            
                return result;
            } else {
                throw new Exception("Bad response: " + response.StatusCode + "/" + response.ReasonPhrase);
            }
        }
    }
}