using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public float range;
    GameObject player;

    public GameObject arrow, firing;


    float timePassed;
    public float waitingTime = 8f;
    void Start()
    {
        timePassed = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;

        player = GameObject.Find("Player");

        if(health <= 0)
        {
            Destroy(gameObject);
        }



        if(Vector3.Distance(transform.position, player.transform.position) <= range)
        {

            transform.LookAt(player.transform.position);

            if (timePassed >= waitingTime)
            {
                timePassed = 0;
                GetComponent<Animator>().SetTrigger("shoot");
                
            }

        }


        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    public void insArrow()
    {
        Instantiate(arrow, firing.transform.position, firing.transform.rotation);
    }


}
