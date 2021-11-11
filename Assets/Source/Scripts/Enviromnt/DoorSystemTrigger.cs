using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enviroment
{
    public class DoorSystemTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.GetComponent<IActor>()!=null)
                DoorSystemEvent.Event.ActionEnter();
        }
    }
}
