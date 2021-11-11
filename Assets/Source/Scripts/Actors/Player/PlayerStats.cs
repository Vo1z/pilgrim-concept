using Extensions;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(PlayerEventController))]
    public class PlayerStats : MonoBehaviour, IActor
    {
        private PlayerEventController _playerEventController;

        private float _currentHp;

        private void Awake()
        {
            _playerEventController = GetComponent<PlayerEventController>();
            _currentHp = _playerEventController.PlayerData.InitialHp;
        }

        private void Die()
        {
            _playerEventController.Die();
        }

        public void TakeDamage(float amountOfDamage)
        {
            amountOfDamage = Mathf.Abs(amountOfDamage);
            _currentHp -= amountOfDamage;
            
            //todo debug
            this.SafeDebug(_currentHp);
            
            if(_currentHp < 1)
                Die();
        }

        public void Heal(float amountOfHp)
        {
            amountOfHp = Mathf.Abs(amountOfHp);
            _currentHp += amountOfHp;
        }
    }
}