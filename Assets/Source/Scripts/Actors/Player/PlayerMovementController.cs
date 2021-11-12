using Extensions;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(PlayerEventController), typeof(Rigidbody))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private PlayerEventController _playerEventController;
        private Rigidbody _rigidbody;
        private bool _isInspectingWeapon;
        private bool _isGrounded;
        private bool _isAiming = false;

        private void Awake()
        {
            _playerEventController = GetComponent<PlayerEventController>();
            _rigidbody = GetComponent<Rigidbody>();
            Cursor.visible = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            _isGrounded = true;
        }
        
        private void OnCollisionExit(Collision other)
        {
            _isGrounded = false;
        }

        private void Update()
        {
            Move();
            Jump();
            Rotate();
            ManageWeapon();
        }

        private void Move()
        {
            var deltaMovement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            deltaMovement = deltaMovement.normalized;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetFloat("Speed", .5f);
                deltaMovement *= _playerEventController.PlayerData.MovementSpeed / 2;
            }
            else
            {
                animator.SetFloat("Speed", 1f);
                deltaMovement *= _playerEventController.PlayerData.MovementSpeed;
            }

            deltaMovement *= Time.deltaTime;
            
            
            if (deltaMovement.magnitude > 0)
            {
                animator.SetBool("Walking", true);
            }
            else
            {
                animator.SetBool("Walking", false);
            }
            
            _rigidbody.position += deltaMovement;
        }

        private void Rotate()
        {
            var deltaRotation = Vector3.up * Input.GetAxis("Mouse X") * _playerEventController.PlayerData.RotationSpeed +
                                Vector3.left * Input.GetAxis("Mouse Y") * _playerEventController.PlayerData.RotationSpeed;
            transform.eulerAngles += deltaRotation;
        }

        private void Jump()
        {
            if(_isGrounded && Input.GetKeyDown(KeyCode.Space))
                _rigidbody.AddForce(Vector3.up * _playerEventController.PlayerData.JumpForce, ForceMode.Impulse);
        }

        private void ManageWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
                _isAiming = !_isAiming;

            if (_isAiming)
            {
                animator.SetTrigger("Aim");
                this.DoAfterNextFrameCoroutine(() => animator.ResetTrigger("Aim"));
            }
            else
            {
                animator.SetTrigger("Idle");
                this.DoAfterNextFrameCoroutine(() => animator.ResetTrigger("Idle"));
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                animator.SetTrigger("Reload");
                this.DoAfterNextFrameCoroutine(() => animator.ResetTrigger("Reload"));
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                if (_isInspectingWeapon)
                {
                    _isInspectingWeapon = false;
                    animator.SetTrigger("Idle");
                    this.DoAfterNextFrameCoroutine(() => animator.ResetTrigger("Idle"));
                }
                else
                {
                    _isInspectingWeapon = true;
                    animator.SetTrigger("Inspect");
                    this.DoAfterNextFrameCoroutine(() => animator.ResetTrigger("Inspect"));
                }
            }
        }
    }
}