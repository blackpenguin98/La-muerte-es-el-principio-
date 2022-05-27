using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<stats>().health = 100;
            GetComponent<Animator>().SetTrigger("open");
            
        }
    }
}

