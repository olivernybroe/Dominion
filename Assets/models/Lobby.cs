using System;
using System.Collections;
using services.authentication;
using UnityEngine;
using UnityEngine.Serialization;

namespace models
{
    
    [Serializable]
    public class Lobby
    {
        public int id;
        
        public string name;

        public string players;

        public IEnumerator Join(string type)
        {
            var www = AuthHttp.Post($"lobbies/{id}/users/{type}", null);

            yield return www.SendWebRequest();
        }

        public IEnumerator JoinAsPlayer()
        {
            return Join("players");
        }
    }
}
