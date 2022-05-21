using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ciclops : MonoBehaviour
{

    private Animator animator;
    private GameObject player;
    private NavMeshAgent controller;


    public float persueRange = 2;
    public float attackingRange = 2;

    bool oncePunch;


    float timePassed = 0;
    public float waitingTime = 2; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        controller = GetComponent<NavMeshAgent>();
        timePassed = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Vector3.Distance(transform.position, player.transform.position) <= persueRange)
        {
            if(Vector3.Distance(transform.position, player.transform.position) <= attackingRange)
            {
                animator.SetBool("isWalking", false);
                
                controller.destination = transform.position;
                Debug.Log("lol");

                if (!oncePunch)
                {
                    oncePunch = true;
                    animator.SetTrigger("Punch");
                    timePassed = 0;
                }


            }
            else
            {
                animator.SetBool("isWalking", true);
                transform.LookAt(player.transform.GetChild(0).position);
                controller.destination = player.transform.position;
                oncePunch = false;
            }

            
        }

        timePassed += Time.deltaTime;

        if(timePassed >= waitingTime)
        {
            oncePunch = false;
        }












    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, persueRange);
        Gizmos.DrawWireSphere(transform.position, attackingRange);
    }


}
