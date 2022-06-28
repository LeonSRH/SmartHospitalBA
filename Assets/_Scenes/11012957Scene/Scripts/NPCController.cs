using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SH.DialogueSystem
{
    public class NPCController : MonoBehaviour
    {
        public delegate void InputEvents();
        public static event InputEvents OnInteract;
        public static event InputEvents OnEnterInteractable;
        public static event InputEvents OnExitInteractable;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "DialogueTrigger")     
            {
                if (OnInteract != null) OnInteract();
                if (OnEnterInteractable != null) OnEnterInteractable();
            }
        }
         //Currently the display disappears if the npc is exiting the static trigger --> Has to be first on the player and than look if
         //* on trigger reactivates the dialogue again

        /*
        private void OnTriggerExit(Collider other)
        {
            if (OnExitInteractable != null) OnExitInteractable();   
        }*/
    }
}
