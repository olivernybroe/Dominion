using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using models;
using services.authentication;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LobbyListController : MonoBehaviour
{
    public GameObject ContentPanel;
    public GameObject ListItemPrefab;
    public Button RefreshButton;

    private Vector2 _defaultAnchorMin;

    // Use this for initialization
    private void Start()
    {
        var panel = ContentPanel.GetComponent<RectTransform>();
        _defaultAnchorMin= new Vector2(panel.anchorMin.x, panel.anchorMin.y);
        Refresh();
        RefreshButton.onClick.AddListener(Refresh);
    }

    public IEnumerator FetchLobbies()
    {
        var www = AuthHttp.Get("lobbies");

        yield return www.SendWebRequest();
     
        Debug.Log(www.downloadHandler.text);

        var lobbies = JsonUtility.FromJson<LobbyCollection>(www.downloadHandler.text);

        lobbies.data.ForEach(lobby => {
            var lobbyView = Instantiate(ListItemPrefab);
            var controller = lobbyView.GetComponent<LobbyListItemController>();
            controller.ApplyLobby(lobby);

            lobbyView.transform.SetParent(ContentPanel.transform, false);

            var panel = ContentPanel.GetComponent<RectTransform>();
            panel.anchorMin = new Vector2(panel.anchorMin.x, panel.anchorMin.y - 0.15f);
        });
    }

    private void Refresh()
    {
        RefreshButton.enabled = false;
        foreach (Transform child in ContentPanel.transform) {
            Destroy(child.gameObject);
        }
        var panel = ContentPanel.GetComponent<RectTransform>();
        panel.anchorMin = _defaultAnchorMin;
        
        StartCoroutine(FetchLobbies());
        RefreshButton.enabled = true;
    }
}
