using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using UnityEngine.UI;
namespace SH.DialogueSystem
{
    public class DialogueReactions : MonoBehaviour
    {
        #region GoToBed Variables

        public GameObject BedTrigger;

        private bool agentUpdater = false;
        public NavMeshAgent agent;

        [SerializeField] private Avatar avatarBed;

        [SerializeField] Transform transformBed;

        #endregion

        public void Update()
        {
            if (agentUpdater)
            {
                agent.SetDestination(BedTrigger.transform.position);
                FaceTarget(BedTrigger.transform.position);
                agent.isStopped = false;
                float distance = Vector3.Distance(gameObject.transform.position, BedTrigger.transform.position);

                if (distance < agent.stoppingDistance)
                {
                    gameObject.GetComponent<Animator>().SetFloat("Laying", 1.0f);
                    gameObject.GetComponent<Animator>().SetFloat("Walking", 0);
                    //gameObject.GetComponent<Animator>().avatar = avatarBed;
                    gameObject.transform.position = transformBed.position;
                    gameObject.transform.rotation = transformBed.rotation;
                    gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    agentUpdater = false;
                }
            }
        }

        private void FaceTarget(Vector3 destination)
        {
            Vector3 lookPos = destination - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);

        }

        public void Start()
        {
            BedTrigger.SetActive(false);
        }

        public void GoToBed()
        {
            BedTrigger.SetActive(true);
            agentUpdater = true;
            gameObject.GetComponent<Animator>().SetFloat("Walking", 1);
           
            //Working
            //something = true; //bool
            //testObject.SetActive(something) // gameObject;
        }
        public void GoToExit()
        {

        }
        public void AssistantTask()
        {

        }
    }
}
