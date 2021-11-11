using UnityEngine;
namespace Ingame.Environment
{
    public class DoorSystemTrigger : MonoBehaviour
    {

        private bool _isTriggered = false;
        public bool IsTriggered => _isTriggered;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IActor actor))
            {
                _isTriggered = true;
                DoorSystemEvent.Instance.ActionEnter();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IActor actor))
            {
                
                DoorSystemEvent.Instance.ActionExit();
                _isTriggered = false;
            }
        }
    }
}
