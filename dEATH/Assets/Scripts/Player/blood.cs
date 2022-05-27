using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{

    public GameObject bloodP;
    public Transform t;
    GameObject bloodI;

    public AudioSource spearHit1, spearhit2;

    public AudioSource[] hitted;
    public AudioSource[] steps;
    public AudioSource[] roll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bloodS()
    {
        if (GameObject.Find("spear:pCylinder3").GetComponent<spear>().hasDamaged)
        {
            hitted[Random.Range(0, hitted.Length)].Play();
            bloodI = Instantiate(bloodP, t.transform.position, t.transform.rotation);
        }
       
    }


    IEnumerator destroyBlood()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(bloodI);
    }

    //spear
    public void deactivaRoll()
    {
        GameObject.Find("Player").GetComponent<playerController>().isRoling = false;
    } 


    public void hit1()
    {
        spearHit1.Play();
    }

    public void hit2()
    {
        spearhit2.Play();
    }

    public void step()
    {
        steps[Random.Range(0, steps.Length)].Play();
    }

    public void rollS()
    {
        roll[Random.Range(0, roll.Length)].Play();
    }


}
