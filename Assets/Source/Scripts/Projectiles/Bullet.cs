using System;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Bullet : MonoBehaviour, IProjectile
    {
        [SerializeField] private float speed;

        private Rigidbody _rigidbody;
        private bool _isFlying = false;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Launch(transform.forward);
        }

        private void FixedUpdate()
        {
            if(_isFlying)
                _rigidbody.position += transform.forward * speed * Time.fixedDeltaTime;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }

        public void Launch(Vector3 direction)
        {
            direction = direction.normalized;
            transform.rotation = Quaternion.LookRotation(direction);
            
            _isFlying = true;
        }
    }
}