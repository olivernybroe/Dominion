using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Lobby
{   
    public class LobbyController : MonoBehaviour
    {
        public Button StartGameButton;
        public Button LeaveLobbyButton;
        public Text LobbyTitle;
        
        private void Start()
        {
            Debug.Assert(global::LobbyController.Instance.Lobby != null);
            
            LobbyTitle.text = global::LobbyController.Instance.Lobby.name;
            StartGameButton.onClick.AddListener(StartGame);
            LeaveLobbyButton.onClick.AddListener(LeaveLobby);
        }


        private void StartGame()
        {
            Debug.Log("Starting the game.");
        }

        public void LeaveLobby()
        {
            Debug.Assert(global::LobbyController.Instance.Lobby != null);
            StartCoroutine(global::LobbyController.Instance.Lobby.Leave());
            global::LobbyController.Instance.Lobby = null;
            SceneManager.LoadScene("LobbyList");
        }
    }
}