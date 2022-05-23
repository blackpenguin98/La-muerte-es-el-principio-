using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biteCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("cerberus").GetComponent<cerberus>().inBiteRange = true;
        }
        

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("cerberus").GetComponent<cerberus>().inBiteRange = false;
        }
    }
}
