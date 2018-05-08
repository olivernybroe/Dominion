using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour
{
	public Button LogoutButton;
	public Button ExitButton;
	public Button SettingsButton;
	
	// Use this for initialization
	private void Start () {
		LogoutButton.onClick.AddListener(LogoutAndRedirect);
		ExitButton.onClick.AddListener(Exit);
	}

	private static void LogoutAndRedirect()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Login");
    }

	private static void Exit()
	{
		Application.Quit();
	}
}
