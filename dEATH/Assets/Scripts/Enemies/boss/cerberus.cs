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

    int actions;
    bool actionsDone = true;
    int actionsLeft;
    public float timeBetweenAction;
    bool onceA;

    public bool inBiteRange;
    public int biteDamage = 20;

    public int health = 10000;


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


        if (actionsDone)
        {
            actions = Random.Range(0, 4);
            actionsLeft = Random.Range(3, 7);
            actionsDone = false;
        }


        if(actionsLeft > 0)
        {
            if(actions == 0)
            {
                if (!onceA)
                {
                    onceA = true;
                    anim.SetTrigger("biting");
                    StartCoroutine(timeBeforeAction());
                }
            }
            if (actions == 1)
            {
                if (!onceA)
                {
                    onceA = true;
                    anim.SetTrigger("Fire");
                    StartCoroutine(timeBeforeAction());
                }
            }
            if (actions == 2)
            {
                if (!onceA)
                {
                    onceA = true;
                    anim.SetTrigger("summon");
                    StartCoroutine(timeBeforeAction());
                }
            }
            if (actions == 3)
            {
                if (!onceA)
                {
                    onceA = true;
                    StartCoroutine(timeBeforeAction());
                }
            }
        }


        if(actionsLeft == 0)
        {
            isResting = true;
        }

        Debug.Log(actionsLeft);

        if (isResting)
        {
            if (!onceR)
            {
                
                onceR = true;
                onceNR = false;
                anim.SetBool("resting", true);
                transform.position = restPos.position;
                headCollider.SetActive(true);
                StartCoroutine(timeBeforeStopResting());
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


    IEnumerator timeBeforeAction()
    {
        yield return new WaitForSeconds(timeBetweenAction);
        actionsLeft -= 1;
        actions = Random.Range(0, 4);
        onceA = false;
    }

    IEnumerator timeBeforeStopResting()
    {
        yield return new WaitForSeconds(timeBetweenAction + 8);
        onceR = false;
        isResting = false;
        actionsDone = true;
    }


    public void bite()
    {
        if (inBiteRange)
        {
            GameObject.Find("Player").GetComponent<stats>().health -= biteDamage;
        }
    }



}
