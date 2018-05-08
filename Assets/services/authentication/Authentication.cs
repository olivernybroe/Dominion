using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace services.authentication
{
    public static class Authentication
    {
        private const string Url = AuthHttp.BaseUrl+"oauth/token";

        public static IEnumerator Login(string email, string password)
        {
            var www = UnityWebRequest.Post(
                Url,
                new Dictionary<string, string>{
                    {"username", email},
                    {"password", password},
                    {"grant_type", "password"},
                    {"client_id", "2"},
                    {"client_secret", "Td7Dl8kTHpJXmHC08ER522bBbzM2mGWXWKAe3h38"}
                }
            );

            yield return www.SendWebRequest();

            var token = JsonUtility.FromJson<Token>(www.downloadHandler.text);

            if(token.access_token != null) {
                PlayerPrefs.SetString("access_token", token.access_token);
            }

        }
    }
}

