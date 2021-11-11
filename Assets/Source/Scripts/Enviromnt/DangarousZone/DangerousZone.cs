using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enviroment {
    public class DangerousZone : MonoBehaviour
    {
        [SerializeField] private float _dmg = 1.2f;
        [HideInInspector]private bool _isOnDangerousZone = false;
        private IActor _player = null;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IActor actor)) {
                _player = actor;
                _isOnDangerousZone = true;
            }
               
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IActor actor))
            {
                _player = null;
                _isOnDangerousZone = false;
            }
        }

        void Start()
        {
            StartCoroutine("TakeDamage");
        }

        private IEnumerator TakeDamage()
        {
            if (_isOnDangerousZone && _player!=null)
            {
                _player.TakeDamage(_dmg);
            }
            yield return new WaitForSeconds(0.3f);
        } 
 
    }
}