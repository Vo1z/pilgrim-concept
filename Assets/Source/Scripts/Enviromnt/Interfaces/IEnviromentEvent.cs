using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Enviroment {
    public interface IEnvromentEvent 
    {
        //enviroment changes
        public event Action OnAction;

        //player triggers action
        public void ActionEnter();
    }
}