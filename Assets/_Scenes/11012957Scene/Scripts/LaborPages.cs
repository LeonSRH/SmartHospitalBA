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

        [SerializeField] List <GameObject> pages;

        [SerializeField] public List<Button> buttonList;

        public void Page1()
        {
            pages[0].SetActive(false);
            StartCoroutine(DelayPage2());
        }
        public void Page2()
        {
            pages[1].SetActive(false);
            StartCoroutine(DelayPage3());
        }
        public void EndLaborParameterErhebung()
        {
            //Definitely not ideal but it works for now with multiple Patients
            dialogueInteract = FindObjectOfType<DialogueInteract>();
            pages[2].SetActive(false);
            dialogueInteract.dialogueCanvas.enabled = true;
            dialogueInteract.dialogueWindow.SetActive(true);
            dialogueInteract.isEventActive = false;
            dialogueInteract.stopWatch.currentTime = 0;
        }

        IEnumerator DelayPage2()
        {
           yield return new WaitForSeconds(0.5f);
           pages[1].SetActive(true);
        }
        IEnumerator DelayPage3()
        {
            yield return new WaitForSeconds(0.5f);
            pages[2].SetActive(true);
        }

        public void ResetButtons()
        {
            foreach(Button button in buttonList)
            {
                ColorBlock cb = button.colors;
                cb.normalColor = Color.grey;
                button.colors = cb; 
            }
            buttonList.Clear();
        }
    }
}
