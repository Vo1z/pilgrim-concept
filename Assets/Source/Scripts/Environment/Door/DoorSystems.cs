using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Environment
{
    public class DoorSystems : MonoBehaviour
    {
        [SerializeField] private float _openRate=25;
        private DoorSystemTrigger _trigger;
        private void Awake()
        {
            
        }
        // Start is called before the first frame update
        void Start()
        {
            DoorSystemEvent.Instance.OnActionEnter += OpenDoor;
            DoorSystemEvent.Instance.OnActionExit += CloseDoor;
        }

        // Update is called once per frame
        private void OpenDoor()
        {
            transform.DOMove(transform.position + Vector3.up * _openRate, 2);
        }
        private void CloseDoor()
        {

            transform.DOMove(transform.position + Vector3.down * _openRate, 2);
        }
         
    }
}