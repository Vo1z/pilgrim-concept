using NaughtyAttributes;
using UnityEngine;

namespace Ingame
{
    public class PlayerEventController : MonoBehaviour
    {
        [Required] [SerializeField] private PlayerData playerData;

        public PlayerData PlayerData => playerData;
    }
}