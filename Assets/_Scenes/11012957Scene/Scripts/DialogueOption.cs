using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SH.DialogueSystem
{
    public class DialogueOption : MonoBehaviour
    {
        DialogueInteract dialogueInteract;

        ReactionBool reactionBools;    

        DialogueObject dialogueObject;

        DialogueReactions dialogueReactions;

        [SerializeField] TMPro.TMP_Text dialogueText;

        [HideInInspector] public bool bedBool;

        //Following functions to pass parameters 
        public void Setup (DialogueInteract _dialogueInteract, DialogueObject _dialogueObject, string _dialogueText)
        {
            dialogueInteract = _dialogueInteract;
            dialogueObject = _dialogueObject;
            dialogueText.text = _dialogueText;
        }
        public void SecondSetup(DialogueReactions _dialogueReactions)
        {
            dialogueReactions = _dialogueReactions;
        }

        //Following functions for event firing 
        public void SelectOption()
        {
            dialogueInteract.OptionSelected(dialogueObject);
        }
        public void BedOption()
        {
            dialogueInteract.GoToBedRedirect();
        }
        public void CorrectAnswer()
        {
            dialogueInteract.CorrectAnswerHandlerRedirect();
        }
        public void SauerstoffTherapieRedirect()
        {
            dialogueInteract.ActivateSauersstoffMaske();
        }
        public void IncorrectAnswer()
        {
            dialogueInteract.InCorrectAnswerHandlerRedirect();
        }
        public void ActivateLaborParameterWindow()
        {
            dialogueInteract.ActivateLaborParameterWindowRedirect();
        }
        public void ActivateDiagnoseParameterWindow()
        {
            dialogueInteract.ActivateDiagnoseEventRedirect();
        }
        public void ActivateSecondDiagnoseParameterWindow()
        {
            dialogueInteract.ActivateSecondDiagnoseEventRedirect();
        }
        public void ActivateST()
        {
            dialogueInteract.ActivateSauersstoffMaske();
        }
        public void EndScenario()
        {
            dialogueInteract.EndScenarioRedirect();
        }
    }
}
