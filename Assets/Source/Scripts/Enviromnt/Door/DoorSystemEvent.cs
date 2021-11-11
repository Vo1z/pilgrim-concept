using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enviroment
{
    public class DoorSystemEvent : MonoBehaviour,IEnvromentEvent
    {
        #region IMPLEMENTED_METHODS
 
        public event Action OnActionEnter;
        public event Action OnActionExit;

        public void ActionEnter()
        {
            if(OnActionEnter == null)
            {
                return;
            }
            OnActionEnter();
            
        }
        public void ActionExit()
        {
            if (OnActionExit == null)
            {
                return;
            }
            OnActionExit();

        }
        #endregion

        public static IEnvromentEvent Event;

        private void Awake()
        {
            Event = this;
        }

    }
}
