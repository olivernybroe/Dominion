using System;
using System.Collections;
using models;
using services.authentication;
using UnityEngine;

namespace Lobby
{
    public class PlayerListAdapter : MonoBehaviour
    {
        public GameObject ContentPanel;
        public GameObject ListItemPrefab;
        
        // Use this for initialization
        private void Start()
        {
            StartCoroutine(LoginAndRedirect());
        }

        public IEnumerator LoginAndRedirect()
        {
            Debug.Assert(global::LobbyController.Instance.Lobby != null);

            var id = global::LobbyController.Instance.Lobby.id;
			
            var www = AuthHttp.Get(
                $"lobbies/{id}/users/players"
            );

            yield return www.SendWebRequest();

            var users = JsonUtility.FromJson<UserCollection>(www.downloadHandler.text);

            users.data.ForEach(user => {
                var lobbyView = Instantiate(ListItemPrefab);
                var controller = lobbyView.GetComponent<PlayerListItemController>();
                controller.ApplyUser(user);

                lobbyView.transform.SetParent(ContentPanel.transform, false);

                var panel = ContentPanel.GetComponent<RectTransform>();
                panel.anchorMin = new Vector2(panel.anchorMin.x, panel.anchorMin.y - 0.15f);
            });
        }
    }
}