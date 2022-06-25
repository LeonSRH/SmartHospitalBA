using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTriggerHandler : MonoBehaviour
{
    //DEPRECATED, REMOVE LATER-----------------------------------------

    //Scene references for gameobjects 
    [SerializeField] public GameObject bedCollider;

    //Scene references for transforms
    [SerializeField] private Transform bedColliderPosition;

    //references of the scene stuff

    [HideInInspector] public GameObject bedColliderReference;
    public void Awake()
    {
     
    }
    public void Start()
    {
        bedColliderReference = Instantiate(bedCollider, bedColliderPosition);
        bedColliderReference.SetActive(false);
    }

}
