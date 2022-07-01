using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace SH.DialogueSystem
{
public class TreatmentChoices : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text textMeshPro;

    [SerializeField] GameObject window;

    [SerializeField] GameObject ownWindow;

    [SerializeField] DialogueInteract dialogueInteract;

    [SerializeField] string DiagnoseText;

    [SerializeField] TreatmentEvent treatmentEvent;

        //switch case

    public enum TreatmentEventProperties { EKG, Thorax, Wrong};
    public TreatmentEventProperties treatmentEventProperties;

    public void TreatmentProperty()
    {
        window.SetActive(true);
        textMeshPro.text = DiagnoseText + " wird durchgefuehrt";
        //dialogueInteract = FindObjectOfType<DialogueInteract>();
        ownWindow.SetActive(false);
    }

    public void TreatmentChoice()
    {
            switch(treatmentEventProperties)
            {
                case TreatmentEventProperties.EKG:

                    EKG();

                    break;
                case TreatmentEventProperties.Thorax:

                    Thorax();

                    break;
                case TreatmentEventProperties.Wrong:

                    WrongChoice();

                    break;
            }
    }
    public void EKG()
    {
            TreatmentProperty();
            treatmentEvent.SelectEKGDiagnose();
            treatmentEvent.StartProgressBar();
        }
    public void Thorax()
    {
            TreatmentProperty();
            treatmentEvent.StartProgressBar();
            treatmentEvent.SelectThoraxDiagnose();
    }

    public void WrongChoice()
    {
            TreatmentProperty();
            treatmentEvent.SelectWrongDiagnose();
            treatmentEvent.StartProgressBar();
    }
}
}
