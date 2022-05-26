using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHanlder : MonoBehaviour
{

    public GameObject col1, col2;
    public EnemieChecker checker;
    bool playerInside;
    // Start is called before the first frame update
    void Start()
    {
        col1.SetActive(false);
        col2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(checker.EnemiesInArea() && playerInside)
        {
            col1.SetActive(true);
            col2.SetActive(true);
        }

        if (!checker.EnemiesInArea())
        {
            col1.SetActive(false);
            col2.SetActive(false);
        }





    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInside = true;
        }
    }

}
