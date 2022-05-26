using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour

{

    public bool inRange;
    public int damage = 10;
    public int health = 10;

    public float range;

    public Animator anim;

    GameObject player;

    public GameObject taget;

    bool attackOnce;

    public float waiting;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        taget = GameObject.Find("handTarget");
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        


        if(Vector3.Distance(transform.position, player.transform.position) <= range)
        {
            if (!attackOnce)
            {
                attackOnce = true;
                anim.SetTrigger("attack");
                StartCoroutine(resetAttack());
                transform.LookAt(taget.transform.position);
            }
        }


    }



    public void attack()
    {
        if (inRange)
        {
            GameObject.Find("Player").GetComponent<stats>().health -= damage;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    IEnumerator resetAttack()
    {
        yield return new WaitForSeconds(waiting);
        attackOnce = false;
    }

}
