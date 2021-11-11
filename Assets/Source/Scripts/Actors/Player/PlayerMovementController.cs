using Support;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(PlayerEventController), typeof(CharacterController))]
    public class PlayerMovementController : MonoBehaviour
    {
        private PlayerEventController _playerEventController;
        private CharacterController _characterController;

        private void Awake()
        {
            _playerEventController = GetComponent<PlayerEventController>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            InputSystem.Instance.OnDragAction += Rotate;
        }

        private void OnDestroy()
        {
            InputSystem.Instance.OnDragAction -= Rotate;
        }

        private void Move()
        {
            
        }

        private void Rotate(Vector2 dragDirection)
        {
            var deltaRotation = Vector3.up * dragDirection.x;
            deltaRotation *= _playerEventController.PlayerData.RotationSpeed;

            transform.Rotate(deltaRotation);
        }
    }
}