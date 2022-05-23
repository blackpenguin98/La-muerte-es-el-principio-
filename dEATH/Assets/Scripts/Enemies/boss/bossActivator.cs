using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossActivator : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("cerberus").GetComponent<cerberus>().isActive = true;
        }
    }
}
