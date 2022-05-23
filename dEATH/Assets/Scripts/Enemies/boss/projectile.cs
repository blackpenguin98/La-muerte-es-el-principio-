using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public int damage = 40;
    public GameObject boom;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<stats>().health -= damage;
            Instantiate(boom, transform.position, Quaternion.identity);
            GameObject.Find("cerberus").GetComponent<cerberus>().isFiring = false;
            Destroy(gameObject);
            
        }

        if(other.tag == "floor")
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            GameObject.Find("cerberus").GetComponent<cerberus>().isFiring = false;
            Destroy(gameObject);
        }

    }
}
