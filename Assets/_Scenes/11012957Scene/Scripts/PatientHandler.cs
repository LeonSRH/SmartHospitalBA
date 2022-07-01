using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SH.DialogueSystem
{
    public class PatientHandler : MonoBehaviour
    {

        [HideInInspector] public bool isScenarioActive = false;

        //List can be later modified, so that patients who are already in the scene and walk into the patient room,
        //the patient gets the currentPatient tag + gets added to the list, later the patient has to be removed from the list
        [SerializeField]  List<GameObject> patients = new List<GameObject>();

        [SerializeField] Text ownText;

        private Text text;

        //Get the Dialogueobject of the currentpatient so that it can be randomized inbetween the patients
        [SerializeField]  private DialogueInteract dialogueInteract;

        [SerializeField] GameObject ownObject;

        [SerializeField] GameObject currentPatient;
        //Function for later, startDialogue cant be on dialoguewindow, because it will start the dialog for every npc
        /*
        public void OnTriggerEnter(Collider other)
        {
            if (gameObject.activeSelf)
            Debug.Log("Trigger is now active");
        }*/

        private void Start()
        {
            Debug.Log(Application.persistentDataPath);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                //Bool to prevent multiple Enterings 
                GetPatientInformations();
                isScenarioActive = true;
            }
        }
        //Method for picking a random scenario (patient prefab) 
        public GameObject GetRandomItem(List<GameObject> listToRandomize)
        {
            int currentDialogueObject = Random.Range(0, listToRandomize.Count);
            GameObject randomObj = listToRandomize[currentDialogueObject];
            return randomObj;
        }
        private void Update()
        {
            if (isScenarioActive)
            {
                StartCoroutine(StartScenario());
            }
        }
        IEnumerator StartScenario()
        {
            yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
            //Select Patient
            currentPatient.SetActive(true);
            currentPatient.tag = "CurrentPatient";
            isScenarioActive = false;
            ownText.text = "Starte Szenario";
            ownObject.SetActive(false);
        }

        public void GetPatientInformations()
        {
            currentPatient = GetRandomItem(patients);
            ownText.text = "Szenario gestartet";
            dialogueInteract = currentPatient.GetComponent<DialogueInteract>();
            if (dialogueInteract.startdialogueObject.name == "Eroeffnungstext")
            {
                Debug.Log("Scenario 1");
                //Activate Scenario Trigger 1
            }
            //Replace Blank Text with other Scenario, testings
            if (dialogueInteract.startdialogueObject.name == "Blank_Text")
            {
                Debug.Log("Scenario 2");
                //Activate Scenario Trigger 2
            }
        }
    }
}
