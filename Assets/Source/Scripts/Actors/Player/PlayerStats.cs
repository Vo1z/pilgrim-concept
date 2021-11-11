using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(PlayerEventController))]
    public class PlayerStats : MonoBehaviour, IActor
    {
        private PlayerEventController _playerEventController;

        private void Awake()
        {
            _playerEventController = GetComponent<PlayerEventController>();
        }

        public void TakeDamage(float amountOfDamage)
        {
            throw new System.NotImplementedException();
        }

        public void Heal(float amountOfHp)
        {
            throw new System.NotImplementedException();
        }
    }
}