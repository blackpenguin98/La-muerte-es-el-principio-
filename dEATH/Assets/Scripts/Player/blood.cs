using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{

    public GameObject bloodP;
    public Transform t;
    GameObject bloodI;
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


}