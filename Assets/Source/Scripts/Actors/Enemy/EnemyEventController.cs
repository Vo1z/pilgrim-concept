using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enemy
{
    public class EnemyEventController : MonoBehaviour
    {
        [Required] [SerializeField]private EnemyData enemyData;
        public event Action<Transform> OnLocateTarget;
        public event Action<Transform> OnLoseTarget;


        public EnemyData EnemyData => enemyData;
        public void LocateTarget(Transform transform)
        {
            if (OnLocateTarget == null) {
                return;
            }
            OnLocateTarget(transform);
        }
        public void LoseTarget (Transform transform)
        {
            if (OnLoseTarget == null)
            {
                return;
            }
            OnLoseTarget(transform);
        }
        

        public void Die()
        {

        }
    }
}