using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieSpawner : MonoBehaviour
{

    bool once;
    public GameObject[] enemies;
    public GameObject[] pos;
    // Start is called before the first frame update
    private void LateUpdate()
    {




        if (!once)
        {

            int numberOfenemies = Random.Range(0, pos.Length);

            for(int i = 0; i <= numberOfenemies; i++)
            {

                Instantiate(enemies[Random.Range(0, enemies.Length)], pos[i].transform.position, Quaternion.identity);
            }

            
            once = true;
        }
    }
}
