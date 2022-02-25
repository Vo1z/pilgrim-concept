using System;
using Support;

namespace Ingame.Environment
{
    public class DoorSystemEvent : MonoSingleton<DoorSystemEvent>
    {
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
    }
}
