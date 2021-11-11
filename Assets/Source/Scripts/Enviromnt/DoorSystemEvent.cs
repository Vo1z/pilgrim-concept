using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enviroment
{
    public class DoorSystemEvent : MonoBehaviour,IEnvromentEvent
    {
        #region IMPLEMENTED_METHODS
        public event Action OnAction;

        public void ActionEnter()
        {
            if(OnAction == null)
            {
                return;
            }
            OnAction();
            
        }

        #endregion

        public static IEnvromentEvent Event;

        private void Awake()
        {
            Event = this;
        }

    }
}
