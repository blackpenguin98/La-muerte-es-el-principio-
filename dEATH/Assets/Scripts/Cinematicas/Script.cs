using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    public Animator gladiator, cerberus;
    public GameObject cam;

    float time = 0;

    bool once, once1, once2, once3, once4;

    public GameObject load, over;
    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = new Vector3(-3.43f, 12.86f, 17.87f);
        
        gladiator.transform.parent.transform.position = new Vector3(-0.4604359f, 9.89f, 15.83305f);
        cam.transform.LookAt(gladiator.gameObject.transform.position + new Vector3(0, 2, 0));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 1.9 && time <= 2.99)
        {


            if (!once)
            {
                load.SetActive(false);
                gladiator.SetTrigger("attack");
                once = true;
            }
            
        }


        if(time >= 2.99 && time <= 4.99)
        {

            if (!once1)
            {
                gladiator.SetTrigger("attack2");
                cerberus.SetTrigger("Fire");
                once1 = true;
                cam.transform.position = new Vector3(7.17f, 13.33f, 6.29f);
                cam.transform.LookAt(gladiator.gameObject.transform.position + new Vector3(0, -1, 0));

            }
        }

        if(time >= 4.99 && time <= 5.99)
        {
            if (!once2)
            {
                once2 = true;
                gladiator.SetTrigger("roll");
                gladiator.SetTrigger("roll2");
                cam.transform.position = new Vector3(-11.8703f, 19.71464f, 33.76282f);
                cam.transform.LookAt(gladiator.gameObject.transform.position + new Vector3(0, 0, 0));
            }
            
        }

        if(time >= 5.99 && time <= 6.99)
        {
            if (!once3)
            {
                once3 = true;
                gladiator.SetTrigger("attack");
            }
        }

        if(time >= 6.99 && time <= 7.3)
        {
            

            if (!once4)
            
            {
                cam.transform.position = new Vector3(-0.4830502f, 20.37737f, 13.91409f);
                cam.transform.LookAt(cerberus.gameObject.transform.position + new Vector3(0, -2, 0));
                once4 = true;
                cerberus.SetTrigger("biting");
            }

        }


    }


    public void bite()
    {
        cam.transform.position = new Vector3(18.19648f, 11.68047f, 20.87338f);
        cam.transform.LookAt(cerberus.gameObject.transform.position + new Vector3(0, 0, 0));
        gladiator.SetTrigger("die");
        //over.SetActive(true);
    }

    public void end()
    {
        over.SetActive(true);
    }


    

}
