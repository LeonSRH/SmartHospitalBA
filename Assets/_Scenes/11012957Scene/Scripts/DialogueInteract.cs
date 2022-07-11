using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace SH.DialogueSystem
{
    public class DialogueInteract : MonoBehaviour
    {
        [SerializeField] public DialogueObject startdialogueObject;

        [SerializeField] public GameObject dialogueWindow;

        [SerializeField] AnswerHandler answerHandler;

        [SerializeField] public AudioSource audioSource;

        [SerializeField] public AudioClip buttonPress;

        [SerializeField] GameObject sauerStoffMaske;

        [SerializeField] public UserDataDecision userDataDecision;

        [SerializeField] DialogueReactions dialogueReactions;

        [SerializeField] GameObject cocoStopwatch;

        [SerializeField] public Canvas dialogueCanvas;

        [SerializeField] public CocoStopwatch stopWatch;

        [SerializeField] TMPro.TMP_Text dialogueText;

        [SerializeField] Transform dialogueOptionsParent;

        [SerializeField] GameObject dialogueOptionsButtonPrefab, dialogueOptionsContainer;

        [SerializeField] public bool isEventActive = false;

        [HideInInspector] public GameObject buttonReference;

        private List<GameObject> spawnsButtons = new List<GameObject>();

        [SerializeField] private List<DialogueObject> dialogueObjects = new List<DialogueObject>();

        bool startButtonDelay = false;

        [SerializeField] bool optionSelected = false;

        public bool isDialogue = false;

        //Function to randomize the dialogue objects at start --> random Disease patterns
        public DialogueObject GetRandomItem(List<DialogueObject>listToRandomize)
        {
            int currentDialogueObject = Random.Range(0, listToRandomize.Count);
            DialogueObject randomObj = listToRandomize[currentDialogueObject];
            return randomObj;
        }
        public void OnEnable()
        {
            //Left commented for now cause of specific dialogue object tests, add later back
            startdialogueObject = GetRandomItem(dialogueObjects);
        }

        public void StartDialogue()
        {
            if (gameObject.tag == "CurrentPatient")
            {
                StartCoroutine(DisplayDialogue(startdialogueObject));
            }
        }
        public void StartDialogue(DialogueObject _dialogueObject)
        {
            StartCoroutine(DisplayDialogue(_dialogueObject));
        }
  
        public void OptionSelected(DialogueObject selectedOption)
        {
            optionSelected = true;
            StartDialogue(selectedOption);
            //make own Event for Audiosources
            audioSource.PlayOneShot(buttonPress);
            //isEventActive = true;
            //Probalby seperate method that gets called (Savestuff)s
            userDataDecision.userData.Add(stopWatch.currentTime);

            foreach(var dialogue in selectedOption.dialogueSegments)
            {

                    userDataDecision.userDecisions.Add(dialogue.dialogueText);
                
            }
            SaveManager.Save(userDataDecision);
        }
        public void GoToBedRedirect()
        {
            dialogueReactions.GoToBed();
        }
        public void EndScenarioRedirect()
        {
            answerHandler.ActivateEndTrigger();
        }

        public void TriggerEvent()
        {
            dialogueWindow.SetActive(false);
            isEventActive = true;
        }
        public void CorrectAnswerHandlerRedirect()
        {
            answerHandler.ShowCorrectAnswer();
        }
        public void InCorrectAnswerHandlerRedirect()
        {
            answerHandler.ShowIncorrectAnswer();
            
        }
        public void ActivateDiagnoseEventRedirect()
        {
            answerHandler.ShowDiagnoseWindow();
            TriggerEvent();
        }

        public void ActivateSecondDiagnoseEventRedirect()
        {
            answerHandler.ShowSecondDiagnoseWindow();
            TriggerEvent();
        }

        public void AssistantTaskRedirect()
        {

        }
        //Dont use, just for testings
        public void ActivateLaborParameterWindowRedirect()
        {
            answerHandler.ShowLaborParameterWindow();
            TriggerEvent();
        }
        public void ActivateSauersstoffMaske()
        {
            sauerStoffMaske.SetActive(true);
        }
        IEnumerator DisplayDialogue(DialogueObject _dialogueObject)
        {
            yield return 0;
            
            if (!isEventActive)
            {
                dialogueCanvas.enabled = true;
            }
            foreach(var dialogue in _dialogueObject.dialogueSegments)
            {
                dialogueText.text = dialogue.dialogueText;
                if (dialogue.dialogueChoices.Count == 0)
                {
                    yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
                }else
                {
                        startButtonDelay = true;
                        cocoStopwatch.SetActive(true);
                        stopWatch.StartStopWatch();
                        dialogueOptionsContainer.SetActive(true);   
                        //Yield Return so that the buttons dont spawn multiple times if the question gets answererd to fast
                        yield return new WaitForSeconds(0.3f);
                        foreach(var option in dialogue.dialogueChoices)
                        {
                            buttonReference = Instantiate(option.Button, dialogueOptionsParent);
                            buttonReference.GetComponent<DialogueOption>().Setup(this, option.followOnDialogue, option.dialogueChoice);
                            spawnsButtons.Add(buttonReference);
                            //newButton.name = ("NewButton" + buttonNummer);
                        }
                    while(!optionSelected)
                    {
                        yield return null;
                    }
                    break;
                }
                yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
                //Has later to be replaced with Option when the Player wants to continue 
            }
            dialogueOptionsContainer.SetActive(false);
            cocoStopwatch.SetActive(false);
            //Currently restarts the Stopwatch if button is pressed, two options: First, save the times in a file or smth, second
            //Last Button stops the Watch 
            startButtonDelay = false;
            stopWatch.StopStopWatch();
            dialogueCanvas.enabled = false;
            optionSelected = false;
            Debug.Log("End of Dialogue");
            spawnsButtons.ForEach (x => Destroy(x));  
        }
    }
}
