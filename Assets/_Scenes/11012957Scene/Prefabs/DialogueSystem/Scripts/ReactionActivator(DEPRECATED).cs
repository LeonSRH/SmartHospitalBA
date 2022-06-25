using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace SH.DialogueSystem
{

    public class ReactionActivator : MonoBehaviour
    {
        void start()
        {
        }

        public void CheckeveryString(DialogueObject dialogueObject)
        {
            foreach(var hs in dialogueObject.dialogueSegments)
            {
                if (hs.dialogueText == "Hallo")
                {
                    Debug.Log("LONFNPOADIJFD");
                }
                else break;
            }
           if (dialogueObject.dialogueSegments.Any(x => x.dialogueText == "Hello"))
            {
                Debug.Log("This works not");
            }
        }
       public void ButtonSelection()
        {
            if (gameObject.name == "NewButton1")
            {
                Debug.Log("NewButton1");
            }
            if (gameObject.name == "NewButton2")
            {
                Debug.Log("NewButton2");
            }
        }
    }
}
