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

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var joystickDirection = InputSystem.Instance.Joystick.Direction;
            var deltaMovement = transform.forward * joystickDirection.y +
                                transform.right * joystickDirection.x +
                                Vector3.down * _playerEventController.PlayerData.GravityForce;
            deltaMovement = deltaMovement.normalized;
            deltaMovement *= _playerEventController.PlayerData.MovementSpeed;
            deltaMovement *= Time.fixedDeltaTime;

            _characterController.Move(deltaMovement);
        }

        private void Rotate(Vector2 dragDirection)
        {
            var deltaRotation = Vector3.up * dragDirection.x;
            deltaRotation *= _playerEventController.PlayerData.RotationSpeed;

            transform.Rotate(deltaRotation);
        }
    }
}