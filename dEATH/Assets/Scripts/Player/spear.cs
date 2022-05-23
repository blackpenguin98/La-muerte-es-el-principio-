using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{

    public int damage = 10;
    public bool hasDamaged;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            Debug.Log("xd");
            other.GetComponent<Ciclops>().health -= damage;
            hasDamaged = true;
        }

        if(other.tag == "boss")
        {
            Debug.Log("lol");
            GameObject.Find("cerberus").GetComponent<cerberus>().health -= damage;
            hasDamaged = true;

        }

    }
}
