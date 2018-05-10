using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace services.authentication
{
    public static class AuthHttp
    {
        public const string BaseUrl = "http://dominion-lobby.test/";
        public const string ApiUrl = BaseUrl+"api/";

        private static UnityWebRequest SetAuth(UnityWebRequest webRequest)
        {
            webRequest.SetRequestHeader(
                "Authorization",
                $"Bearer {PlayerPrefs.GetString("access_token")}"
            );
            return webRequest;
        }
        
        public static UnityWebRequest Get(string url)
        {
            var www = UnityWebRequest.Get(ApiUrl+url);
            www = SetAuth(www);
            return www;
        }    
    
        public static UnityWebRequest Post(string url, Dictionary<string, string> data)
        {
            var www = UnityWebRequest.Post(ApiUrl+url, data);
            www = SetAuth(www);
            return www;
        }
    }
}
