using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SH.DialogueSystem
{
    public class AnswerHandler : MonoBehaviour
    {

        [SerializeField] GameObject answerCorrect, answerIncorrect, laborParameterObject, diagnoseWindowSC1, secondDiagnoseWindowSC1;

        [SerializeField] GameObject scenarioEndTrigger;

        //[SerializeField] GameObject answerIncorrect;

        //Not working yet, maybe fix in future
        /*
        IEnumerator FadeOut()
        {
            for (float f = 1f; f >= -0.05f; f-=0.05f)
            {
                Color c = answerCorrect.material.color;
                c.a = f;
                answerCorrect.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
        }*/
        IEnumerator AnswerCorrect()
        {
            answerCorrect.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            answerCorrect.SetActive(false);
        }
        IEnumerator AnserIncorrect()
        {
            answerIncorrect.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            answerIncorrect.SetActive(false);
        }

        public void ShowCorrectAnswer()
        {
            StartCoroutine(AnswerCorrect());
        }
        public void ShowIncorrectAnswer()
        {
            StartCoroutine(AnserIncorrect());
        }
        public void ShowLaborParameterWindow()
        {
                laborParameterObject.SetActive(true);
        }
        public void ShowDiagnoseWindow()
        {
                diagnoseWindowSC1.SetActive(true);
        }
        public void ShowSecondDiagnoseWindow()
        {
            secondDiagnoseWindowSC1.SetActive(true);
        }
        public void ActivateEndTrigger()
        {
            scenarioEndTrigger.SetActive(true);    
        }
    }
}
