using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SH.DialogueSystem
{
    public class DialogueInteract : MonoBehaviour
    {
        [SerializeField] DialogueObject dialogueObject;

        [SerializeField] public UserDataDecision userDataDecision;

        [SerializeField] DialogueReactions dialogueReactions;

        [SerializeField] GameObject cocoStopwatch;

        [SerializeField] Canvas dialogueCanvas;

        [SerializeField] CocoStopwatch stopWatch;
        //Testings
        [SerializeField] List<DialogueObject> dialogueObjects = new List<DialogueObject>();

        [SerializeField] TMPro.TMP_Text dialogueText;

        [SerializeField] Transform dialogueOptionsParent;

        [SerializeField] GameObject dialogueOptionsButtonPrefab, dialogueOptionsContainer;

        [SerializeField] bool isEventActive = false;

        [HideInInspector] public GameObject buttonReference; 

        bool optionSelected = false;

        public bool isDialogue = false;

        //Function to randomize the dialogue objects at start --> random Disease patterns
        //Left commented for now cause of specific dialogue object tests, add later back
        /*
        public DialogueObject GetRandomItem(List<DialogueObject>listToRandomize)
        {
            int currentDialogueObject = Random.Range(0, listToRandomize.Count);
            DialogueObject randomObj = listToRandomize[currentDialogueObject];
            return randomObj;
        }*/
        public void Start()
        {
            //Left commented for now cause of specific dialogue object tests, add later back
            //dialogueObject = GetRandomItem(dialogueObjects);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartDialogue();
            }
        }
        //bool for Behavior Tree, so that if the dialogue ends, the patient leaves
        public void StartDialogue()
        {
            StartCoroutine(DisplayDialogue(dialogueObject));
        }
        public void StartDialogue(DialogueObject _dialogueObject, ReactionBool _reactionBool)
        {
            StartCoroutine(DisplayDialogue(_dialogueObject));
        }
        public void OptionSelected(DialogueObject selectedOption)
        {
            optionSelected = true;
            dialogueObject = selectedOption;
            //isEventActive = true;
            //So far it works, needs more testings
            if (!isEventActive)
            {
                StartDialogue();
            }
            
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
        public void AssistantTaskRedirect()
        {

        }
        IEnumerator DisplayDialogue(DialogueObject _dialogueObject)
        {
            yield return 0;
            List<GameObject> spawnsButtons = new List<GameObject>();

            dialogueCanvas.enabled = true;
            foreach(var dialogue in _dialogueObject.dialogueSegments)
            {
                dialogueText.text = dialogue.dialogueText;
                if (dialogue.dialogueChoices.Count == 0)
                {
                    yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
                }else
                {
                        cocoStopwatch.SetActive(true);
                        stopWatch.StartStopWatch();
                        dialogueOptionsContainer.SetActive(true);   
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
            stopWatch.StopStopWatch();
            dialogueCanvas.enabled = false;
            optionSelected = false;
            Debug.Log("End of Dialogue");
            spawnsButtons.ForEach (x => Destroy(x));  
        }
    }
}
