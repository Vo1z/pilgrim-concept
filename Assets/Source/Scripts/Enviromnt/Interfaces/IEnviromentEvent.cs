using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Enviroment {
    public interface IEnvromentEvent 
    {
        //enviroment changes
        public event Action OnActionEnter;

        //player triggers action
        public void ActionEnter();
        public event Action OnActionExit;
        public void ActionExit();
    }
}