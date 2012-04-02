using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace SO_Dailymotion_Upload
{
    class Program
    {
        static void Main(string[] args)
        {
            var accessToken = GetAccessToken();

            Console.WriteLine(accessToken);
        }

        private static object GetAccessToken()
        {
            var request = WebRequest.Create("https://api.dailymotion.com/oauth/token");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var requestString = String.Format("grant_type=password&client_id={0}&client_secret={1}&username={2}&password={3}",
                HttpUtility.UrlEncode(SettingsProvider.Key),
                HttpUtility.UrlEncode(SettingsProvider.Secret),
                HttpUtility.UrlEncode(SettingsProvider.Username),
                HttpUtility.UrlEncode(SettingsProvider.Password));

            var requestBytes = Encoding.UTF8.GetBytes(requestString);

            var requestStream = request.GetRequestStream();

            requestStream.Write(requestBytes, 0, requestBytes.Length);

            var response = request.GetResponse();

            var responseStream = response.GetResponseStream();
            string responseString;
            using (var reader = new StreamReader(responseStream))
            {
                responseString = reader.ReadToEnd();
            }

            var oauthResponse = JsonConvert.DeserializeObject<OAuthResponse>(responseString);

            return oauthResponse.access_token;
        }
    }
}
