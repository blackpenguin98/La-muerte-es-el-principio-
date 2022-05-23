using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{


    public int health = 100;
    public int stamina = 10000;
    public GameObject die;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stamina = Mathf.Clamp(stamina, 0, 20000);
        if(health <= 0)
        {
            die.SetActive(true);
        }
    }
}
