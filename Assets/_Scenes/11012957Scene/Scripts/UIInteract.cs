using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SH.DialogueSystem
{
    public class UIInteract : MonoBehaviour
    {
        [SerializeField] Canvas canvas;
        [SerializeField] UnityEvent OnInteract;
        [SerializeField] UnityEvent OnEnterInteractable;

        void Awake()
        {
            canvas.enabled = false;
        }
        void OnEnable()
        {
            NPCController.OnInteract += Interact;
            NPCController.OnEnterInteractable += ResetInteract;
            NPCController.OnEnterInteractable += ShowUI;
            NPCController.OnExitInteractable += HideUI;
        }
        void OnDisable()
        {
            NPCController.OnInteract -= Interact;
            NPCController.OnEnterInteractable -= ShowUI;
            NPCController.OnEnterInteractable -= ResetInteract;
            NPCController.OnExitInteractable -= HideUI;
        }
        public void Interact()
        {
            Debug.Log("Interacting");
            OnInteract.Invoke();
        }

        public void ResetInteract()
        {
            OnEnterInteractable.Invoke();
        }

        void ShowUI()
        {
            canvas.enabled = true;
        }

        void HideUI()
        {
            canvas.enabled = false;
        }
    }
}
