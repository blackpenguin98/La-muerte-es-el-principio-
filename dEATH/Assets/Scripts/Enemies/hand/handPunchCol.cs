using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handPunchCol : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.parent.GetComponent<hand>().inRange = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.parent.GetComponent<hand>().inRange = false;
        }
    }


}
