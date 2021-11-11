using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enviroment
{
    public class DoorSystemTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IActor actor))
            {
                DoorSystemEvent.Event.ActionEnter();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IActor actor))
            {
                DoorSystemEvent.Event.ActionExit();
            }
        }
    }
}
