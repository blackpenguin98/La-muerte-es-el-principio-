using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieSpawner : MonoBehaviour
{

    bool once;
    public GameObject troll;
    public GameObject[] pos;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        if (!once)
        {
            Instantiate(troll, pos[0].transform.position, Quaternion.identity);
            once = true;
        }
    }
}
