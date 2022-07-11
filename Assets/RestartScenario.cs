using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScenario : MonoBehaviour
{
    [SerializeField] GameObject activateScenarioTrigger, patientBedPos, patientComingFromOutsidePos, informationPos;

    [SerializeField] List<GameObject> people, patientInformations, patientTherapyObjects;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip scenarioActiveAudio;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activateScenarioTrigger.SetActive(true);
            DeactivateAllPeopleInScene();
            gameObject.transform.parent.gameObject.SetActive(false);
            audioSource.PlayOneShot(scenarioActiveAudio);
        }
    }
    public void DeactivateAllPeopleInScene()
    {
        //Reset the positions for specific patients
        foreach (var person in people)
        {
            if (person != null)
            {
                person.SetActive(false);
                person.tag = "Untagged";
            }
        }
        foreach(var information in patientInformations)
        {
            if (information != null)
            {
                information.SetActive(false);
                information.transform.position = informationPos.transform.position;
            }
        }

        foreach (var therapie in patientTherapyObjects)
        {
            if (therapie != null)
            {
                therapie.SetActive(false);
            }
        }
        //Maybe change later, so that the currentPatient gets added to a list, which gets then a reposition

        foreach (var person in people)
        {
            if (person != null)
            {
                person.transform.position = patientBedPos.transform.position;
            }
        }
    }

}
