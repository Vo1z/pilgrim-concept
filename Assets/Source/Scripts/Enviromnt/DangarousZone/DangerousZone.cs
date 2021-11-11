using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enviroment {
    public class DangerousZone : MonoBehaviour
    {
        [SerializeField] private float _dmg = 1.2f;
        [SerializeField] private IActor _player;
        private bool _isOnDangerousZone = false;
        private void OnCollisionEnter(Collision collision)
        {
            _isOnDangerousZone = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            _isOnDangerousZone = false;
        }

        void Start()
        {
            StartCoroutine("TakeDamage");
        }

        private IEnumerator TakeDamage()
        {
            if (_isOnDangerousZone)
            {
                _player.TakeDamage(_dmg);
            }
            yield return new WaitForSeconds(0.3f);
        } 
 
    }
}