using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ParameterEvent : MonoBehaviour
{
    public void ParmeterDone()
    {
       var currentbutton = GetComponent<Button>().colors;
        currentbutton.normalColor = Color.green;
        GetComponent<Button>().colors = currentbutton;
    }

}
