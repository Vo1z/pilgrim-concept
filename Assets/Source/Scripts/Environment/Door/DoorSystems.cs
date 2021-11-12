using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Environment
{
    public class DoorSystems : MonoBehaviour
    {
        [SerializeField] private float openRate=25;
        private DoorSystemTrigger _trigger;
        private void Awake()
        {
            _trigger = gameObject.GetComponentInChildren<DoorSystemTrigger>();
        }
 
        void Start()
        {
            DoorSystemEvent.Instance.OnActionEnter += OpenDoor;
            DoorSystemEvent.Instance.OnActionExit += CloseDoor;
        }

 
        private void OpenDoor()
        {
            if (!_trigger.IsTriggered)
            {
                return;
            }
            transform.DOMove(transform.position + Vector3.up * openRate, 2);
            
        }
        private void CloseDoor()
        {
            if (!_trigger.IsTriggered)
            {
                transform.DOMove(transform.position + Vector3.down * openRate, 2);
            }
        }
         
    }
}