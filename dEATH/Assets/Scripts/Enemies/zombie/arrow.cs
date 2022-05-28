using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    public float speed = 9;
    public int damage = 20;
    GameObject player;
    public float arrowhitted;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyArrow());
        audioSource = GameObject.Find("Archer_Hit_1").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        transform.Translate(-Vector3.forward * Time.deltaTime * speed);

        if(Vector3.Distance(transform.position, player.transform.position) <= arrowhitted)
        {
            player.GetComponent<stats>().health -= damage;
            audioSource.Play();
            Destroy(gameObject);
        }


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        other.GetComponent<stats>().health -= damage;
    //        Destroy(gameObject);
    //    }
    //}


    IEnumerator destroyArrow()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }

}
