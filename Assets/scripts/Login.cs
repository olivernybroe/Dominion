using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using services.authentication;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{

    public InputField email;
    public InputField password;

    public void Start()
    {
        RedirectIfLoggedIn();
    }

    public void LogInClicked()
    {
        StartCoroutine(LoginAndRedirect());
    }

    public IEnumerator LoginAndRedirect()
    {
        // Execute the login request
        yield return StartCoroutine(
            Authentication.Login(
                email.text,
                password.text
            )
        );
        RedirectIfLoggedIn();
    }

    public void RedirectIfLoggedIn()
    {

        bool hasToken = PlayerPrefs.HasKey("access_token");

        if (!hasToken)
        {
            Debug.Log("failed logging in.");
        }
        else
        {
            Debug.Log("Sucess logging in.");
            SceneManager.LoadScene("LobbyList");
        }
    }
}