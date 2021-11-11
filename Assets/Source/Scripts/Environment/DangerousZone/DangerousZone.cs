using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace Ingame.Environment
{
    public class DangerousZone : MonoBehaviour
    {

        internal class DamageZoneInfo
        {
            public Coroutine Coroutine;
            public IActor Actor;
        }
        private bool TomaszewskiHatesBreak = true;
        [SerializeField] private float _dmg = 1.2f;
        private List<DamageZoneInfo> _zoneInfoList = new List<DamageZoneInfo>(); 
        private const float PAUSE_BETWEEN_HITTING_ACTOR = .3f;
        
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out IActor actor))
            {
                var cor = StartHittingActor(actor);
                _zoneInfoList.Add(new DamageZoneInfo() { Coroutine=cor,Actor=actor});
            }

        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.TryGetComponent(out IActor actor))
            {
                DamageZoneInfo res = _zoneInfoList.Find(a => a.Actor == actor);
                StopHittingActor(res.Coroutine);
                _zoneInfoList.Remove(res);
            }
        }

        private Coroutine StartHittingActor(IActor actor)
        {
            return StartCoroutine(TakeDamageRoutine(actor));
        }
        private void StopHittingActor(Coroutine cor) {
            StopCoroutine(cor);
        }
        private IEnumerator TakeDamageRoutine(IActor actor)
        {
            while (TomaszewskiHatesBreak) {
                actor.TakeDamage(_dmg);
                yield return new WaitForSeconds(PAUSE_BETWEEN_HITTING_ACTOR);
            }
        }
    }
}