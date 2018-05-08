using UnityEngine;
using UnityEngine.UI;


namespace Lobby
{   
    public class LobbyController : MonoBehaviour
    {
        public Button StartGameButton;
        public Text LobbyTitle;
        
        private void Start()
        {
            Debug.Assert(global::LobbyController.Instance.Lobby != null);
            
            LobbyTitle.text = global::LobbyController.Instance.Lobby.name;
            StartGameButton.onClick.AddListener(StartGame);
        }


        private void StartGame()
        {
            Debug.Log("Starting the game.");
        }
    }
}