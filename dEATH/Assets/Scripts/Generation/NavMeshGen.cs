using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGen : MonoBehaviour
{

    GameObject[] surfaces;
    bool bakeOnce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!bakeOnce)
        {
            bakeOnce = true;
            surfaces = GameObject.FindGameObjectsWithTag("floor");

            for(int i = 0; i < surfaces.Length; i++)
            {
                if (surfaces[i].GetComponent<NavMeshSurface>() != null)
                {
                    surfaces[i].GetComponent<NavMeshSurface>().BuildNavMesh();
                }
                
            }



        }
        
    }
}
