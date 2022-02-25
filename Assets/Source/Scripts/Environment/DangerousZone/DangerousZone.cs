using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Environment
{
    public class DangerousZone : MonoBehaviour
    {
        [ShowIf("isWorking")][SerializeField] private float dmg = 1.2f;
        [ShowIf("isWorking")][SerializeField] private float pauseBetweenHittingActor = .3f;
        [Space]
        public bool isWorking = true;

        private Dictionary<IActor, Coroutine> _zoneInfoList = new Dictionary<IActor, Coroutine>();

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out IActor actor))
            {
                var cor = StartHittingActor(actor);
                _zoneInfoList.Add(actor, cor);
            }

        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.TryGetComponent(out IActor actor))
            {
                var cor = _zoneInfoList[actor];
                StopHittingActor(cor);
                _zoneInfoList.Remove(actor);
            }
        }

        private Coroutine StartHittingActor(IActor actor)
        {
            return StartCoroutine(TakeDamageRoutine(actor));
        }

        private void StopHittingActor(Coroutine cor)
        {
            StopCoroutine(cor);
        }

        private IEnumerator TakeDamageRoutine(IActor actor)
        {
            while (isWorking)
            {
                actor.TakeDamage(dmg);
                yield return new WaitForSeconds(pauseBetweenHittingActor);
            }
        }
    }
}