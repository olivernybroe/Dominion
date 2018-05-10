using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using models;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyListItemController : MonoBehaviour
{
	private models.Lobby _lobby;
	
    public Text LobbyItemText;

    public Text LobbyItemPlayers;

	public Button LobbyItemButtonJoin;

	public void ApplyLobby([NotNull] models.Lobby lobby)
	{
		_lobby = lobby;
		LobbyItemText.text = lobby.name;
		LobbyItemPlayers.text = lobby.players;

		LobbyItemButtonJoin.onClick.AddListener(JoinLobby);
	}
	
	private void JoinLobby()
	{
		StartCoroutine(_lobby.JoinAsPlayer());
		LobbyController.Instance.Lobby = _lobby;
		SceneManager.LoadScene("Lobby");
	}
}
