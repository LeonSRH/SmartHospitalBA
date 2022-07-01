using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BehaviorDesigner.Runtime.ObjectDrawers;

namespace SH.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueObject", menuName = "NPC DialogueObject", order = 0)]

    public class DialogueObject : ScriptableObject
    {
        [Header("Dialogue")]
        public List <DialogueSegment> dialogueSegments = new List<DialogueSegment>();

        [Header("Follow on dialogue - optional")]
        public DialogueObject endDialogue;

    }
    [System.Serializable]
    public struct DialogueSegment
    {
        public string dialogueText;
        public float dialogueDisplayTime;
        public List<DialogueChoice> dialogueChoices;
        public List<GameObject> buttons;
    }

    [System.Serializable]
    public struct DialogueChoice
    {
        [SerializeField] public string dialogueChoice;
        [SerializeField] public DialogueObject followOnDialogue;
        [SerializeField] public GameObject Button;
    }
}
