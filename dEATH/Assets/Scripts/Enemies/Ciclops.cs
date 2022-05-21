using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ciclops : MonoBehaviour
{
    public int health;

    private Animator animator;
    private GameObject player;
    private NavMeshAgent controller;


    public float persueRange = 2;
    public float attackingRange = 2;

    bool oncePunch;

    bool hasHit;


    float timePassed = 0;
    public float waitingTime = 2;

    bool attaking;
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

        if(health > 0) { 
        

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

                attaking = true;

            }
            else if(Vector3.Distance(transform.position, player.transform.position) <= persueRange && !attaking)
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
            attaking = false;
           
        }



        } else
        {
            Destroy(gameObject);
        }








    }



    public void hitCollisionAnim()
    {
        if (hasHit)
        {
            player.transform.Translate(transform.GetChild(4).forward * Time.deltaTime * 1500);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hasHit = true;
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hasHit = false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, persueRange);
        Gizmos.DrawWireSphere(transform.position, attackingRange);
    }


}
