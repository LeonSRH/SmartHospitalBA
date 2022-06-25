using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.DialogueSystem
{
    [CreateAssetMenu(fileName = "ReactionBool", menuName = "NPC ReactionBool", order = 1)]
    public class ReactionBool : ScriptableObject
    {

            [Header("BedBool")]
            public bool bedBool = false;
            [Header("OtherBool")]
            public bool otherBool = false;

    }
}
