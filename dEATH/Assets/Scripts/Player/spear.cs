using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{

    public int damage = 10;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            other.GetComponent<Ciclops>().health -= damage;
        }
    }
}
