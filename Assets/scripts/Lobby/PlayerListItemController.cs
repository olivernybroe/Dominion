using JetBrains.Annotations;
using models;
using UnityEngine;
using UnityEngine.UI;

namespace Lobby
{
    public class PlayerListItemController : MonoBehaviour
    {
        public User _User;
        
        public Text PlayerItemText;

        public void ApplyUser([NotNull] User user)
        {
            _User = user;
            PlayerItemText.text = user.name;
        }
    }
}