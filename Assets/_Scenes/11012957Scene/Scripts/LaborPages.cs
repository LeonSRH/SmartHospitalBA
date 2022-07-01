using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SH.DialogueSystem
{

    public class LaborPages : MonoBehaviour
    {
        [SerializeField] DialogueInteract dialogueInteract;

        //[SerializeField] GameObject delayButton;

        [SerializeField] GameObject page1;

        [SerializeField] GameObject page2;

        [SerializeField] GameObject page3;


        public void Page1()
        {
            page1.SetActive(false);
            StartCoroutine(DelayPage2());
        }
        public void Page2()
        {
            page2.SetActive(false);
            StartCoroutine(DelayPage3());
        }
        public void EndLaborParameterErhebung()
        {
            //Definitely not ideal but it works for now with multiple Patients
            dialogueInteract = FindObjectOfType<DialogueInteract>();
            page3.SetActive(false);
            dialogueInteract.dialogueCanvas.enabled = true;
            dialogueInteract.dialogueWindow.SetActive(true);
            dialogueInteract.isEventActive = false;
            dialogueInteract.stopWatch.currentTime = 0;
        }


        IEnumerator DelayPage2()
        {
           yield return new WaitForSeconds(0.5f);
           page2.SetActive(true);
        }
        IEnumerator DelayPage3()
        {
            yield return new WaitForSeconds(0.5f);
            page3.SetActive(true);
        }

    }
}
