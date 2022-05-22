using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerberus : MonoBehaviour
{

    Animator anim;
    public Transform originalPos, restPos;
    public GameObject headCollider;
    public bool isResting;
    bool onceR, onceNR;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = originalPos.position;
        headCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isResting)
        {
            if (!onceR)
            {
                
                onceR = true;
                anim.SetBool("resting", true);
                transform.position = restPos.position;
                headCollider.SetActive(true);
            }
        }
        else
        {

            if (!onceNR)
            {
                onceNR = true;
                anim.SetBool("resting", false);
                transform.position = originalPos.position;
                headCollider.SetActive(false);
            }
                
            
        }
    }
}
