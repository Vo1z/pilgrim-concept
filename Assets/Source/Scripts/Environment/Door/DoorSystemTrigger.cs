using UnityEngine;
namespace Ingame.Environment
{
    public class DoorSystemTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IActor actor))
            {
                DoorSystemEvent.Instance.ActionEnter();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IActor actor))
            {
                DoorSystemEvent.Instance.ActionExit();
            }
        }
    }
}
