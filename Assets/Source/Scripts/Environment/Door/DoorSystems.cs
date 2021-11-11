using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Environment
{
    public class DoorSystems : MonoBehaviour
    {
        [SerializeField] private float _openRate=25;
        // Start is called before the first frame update
        void Start()
        {
            DoorSystemEvent.Instance.OnActionEnter += OpenDoor;
            DoorSystemEvent.Instance.OnActionEnter += CloseDoor;
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