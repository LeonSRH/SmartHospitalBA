using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SH.DialogueSystem
{
    public class ParameterEvent : MonoBehaviour
    {
        [SerializeField] private LaborPages laborPages;

         private List<Button> buttonList;

        private void Awake()
        {
           buttonList = laborPages.buttonList;
        }
        public void ParmeterDone()
        {
           var currentbuttoncolor = GetComponent<Button>().colors;
           var currentbutton = GetComponent<Button>();
           currentbuttoncolor.normalColor = Color.green;
           GetComponent<Button>().colors = currentbuttoncolor;
           if (!buttonList.Contains (currentbutton))
           {
                buttonList.Add(currentbutton);
           }
        }
    }
}
