using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Enviroment
{
    public class DoorSystems : MonoBehaviour
    {
        [SerializeField] private float _openRate=25;
        // Start is called before the first frame update
        void Start()
        {
            DoorSystemEvent.Event.OnActionEnter += OpenDoor;
            DoorSystemEvent.Event.OnActionEnter += CloseDoor;
        }

        // Update is called once per frame
        private void OpenDoor()
        {
            //open
            transform.DOMove(transform.position - Vector3.up*_openRate,2);
            
        }
        private void CloseDoor()
        {
            transform.DOMove(transform.position + Vector3.up * _openRate, 2);
        }
         
    }
}