using System;
using NaughtyAttributes;
using Support;
using UnityEngine;

namespace Ingame
{
    public class PlayerEventController : MonoBehaviour
    {
        [Required] [SerializeField] private PlayerData playerData;
        
        public event Action OnDeath;
        
        public PlayerData PlayerData => playerData;

        public void Die()
        {
            OnDeath?.Invoke();
            
            //todo reduce hardcode
            LevelManager.Instance.RestartLevel();
        }
    }
}