using JetBrains.Annotations;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    public static LobbyController Instance;

    private void Awake() 
    {
        InstantiateController();
    }

    [CanBeNull] public models.Lobby Lobby { get; set; }

    private void InstantiateController() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if(this != Instance) {
            Destroy(gameObject);
        }
    }
}