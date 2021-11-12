using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ingame.Enemy {
    [RequireComponent(typeof(CharacterController))]
    public class EnemyMovement : MonoBehaviour
    {
        private EnemyEventController _enemyController;
        private Rigidbody _rb;
        private bool _startFollow = true;
        private float _movementSpeed;
        private float _rotationSpeed;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _enemyController = GetComponent<EnemyEventController>();
            _movementSpeed = _enemyController.EnemyData.MovementSpeed;
            _rotationSpeed = _enemyController.EnemyData.RoatationSpeed;
        }
        private void Start()
        {
            _enemyController.OnLocateTarget += followTarget;
        }
        private void Update()
        {

        }

        private void loseTarget()
        {
            
        }

        private void followTarget(Transform target)
        {
            StartCoroutine(followTargetCoroutine(target));
        }


        private IEnumerator followTargetCoroutine(Transform target)
        {
            while (_startFollow) {
                Vector3 dir = (target.position - transform.position).normalized;

                _rb.rotation = Quaternion.Euler(_rb.rotation.x*dir.x/dir.z*_rotationSpeed, 0, _rb.rotation.z* dir.z / dir.x* _rotationSpeed);

                _rb.MovePosition(transform.position + (dir*Time.deltaTime*_movementSpeed));
                yield return new WaitForEndOfFrame();
            } 
        }
     
    } 
}
