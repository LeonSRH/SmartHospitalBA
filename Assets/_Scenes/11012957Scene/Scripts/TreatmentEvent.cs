using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SH.DialogueSystem
{
    public class TreatmentEvent : MonoBehaviour
    {
        [SerializeField] Slider slider;

        [SerializeField] GameObject button;

        [SerializeField] List<GameObject> diagnoseGif;

        [SerializeField] GameObject treatmentEventWindow;

        [SerializeField] Image sliderColor;

        [SerializeField] DialogueInteract dialogueInteract;

        private bool isBar;

        private void Update()
        {
            if (isBar)
            {
                StartCoroutine(progressBarRun());
            }
        }
        public void StartProgressBar()
        {
            if (gameObject.activeSelf)
            {
                isBar = true;
            }
        }
        public void SelectWrongDiagnose()
        {
            SliderRed();
        }
        public void SelectEKGDiagnose()
        {
            diagnoseGif[1].SetActive(true);
            SliderGreen();
        }
        public void SelectThoraxDiagnose()
        {
            diagnoseGif[0].SetActive(true);
            SliderGreen();

        }
        private void SliderGreen()
        {
            sliderColor.color = Color.green;
        }
        private void SliderRed()
        {
            sliderColor.color = Color.red;
        }
        IEnumerator progressBarRun()
        {
            slider.value += 1f * Time.deltaTime;
            if (slider.value >= slider.maxValue)
            {
                button.SetActive(true);
            }
            yield return new WaitForSeconds(5);
            isBar = false;
        }

        public void DeactivateTreatmentEvent()
        {
            sliderColor.color = Color.grey;
            foreach (var images in diagnoseGif)
            {
                images.SetActive(false);
            }
            isBar = false;
            slider.value = 0;
            treatmentEventWindow.SetActive(false);
            dialogueInteract = FindObjectOfType<DialogueInteract>();
            dialogueInteract.dialogueCanvas.enabled = true;
            dialogueInteract.dialogueWindow.SetActive(true);
            dialogueInteract.stopWatch.currentTime = 0;
            dialogueInteract.isEventActive = false;
            button.SetActive(false);
        }

    }
}
