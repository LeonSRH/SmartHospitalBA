using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDeactivate : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponentInParent<GameObject>().SetActive(false);
        }
    }

}
