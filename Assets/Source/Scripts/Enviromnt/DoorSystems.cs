using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Enviroment
{
    public class DoorSystems : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DoorSystemEvent.Event.OnAction += OpenDoor;
        }

        // Update is called once per frame
        private void OpenDoor()
        {
            //open
            transform.DOMove(transform.position - Vector3.up*5,2);
            
        }
         
    }
}