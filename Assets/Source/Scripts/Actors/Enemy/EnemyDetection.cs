using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enemy
{
    [RequireComponent(typeof(CharacterController))]
    public class EnemyDetection : MonoBehaviour
    {
        EnemyEventController enemyController;
        private void Awake()
        {
            enemyController = GetComponent<EnemyEventController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovementController controller)) {
                enemyController.LocateTarget(controller.transform);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out PlayerMovementController controller))
            {
                enemyController.LoseTarget(controller.transform);
            }
        }
    }
}
