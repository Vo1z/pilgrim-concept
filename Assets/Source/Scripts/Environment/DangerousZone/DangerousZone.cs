using System.Collections;
using Extensions;
using UnityEngine;

namespace Ingame.Environment
{
    public class DangerousZone : MonoBehaviour
    {
        [SerializeField] private float _dmg = 1.2f;

        private const float PAUSE_BETWEEN_HITTING_ACTOR = .3f;
        private IActor _player = null;

        private void Start()
        {
            StartCoroutine(TakeDamageRoutine());
        }

        private void OnTriggerEnter(Collider collision)
        {
            this.SafeDebug("enter");
            if (collision.TryGetComponent(out IActor actor))
            {
                _player = actor;
                StartHittingActor();
            }

        }

        private void OnTriggerExit(Collider collision)
        {
            this.SafeDebug("exit");
            if (collision.TryGetComponent(out IActor actor))
            {
                _player = null;
            }
        }

        private void StartHittingActor()
        {
            StopAllCoroutines();
            StartCoroutine(TakeDamageRoutine());
        }

        private IEnumerator TakeDamageRoutine()
        {
            while (_player != null)
            {
                _player.TakeDamage(_dmg);
                
                yield return new WaitForSeconds(PAUSE_BETWEEN_HITTING_ACTOR);
            }
        }
    }
}