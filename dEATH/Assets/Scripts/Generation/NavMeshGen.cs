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
            GetComponent<NavMeshSurface>().BuildNavMesh();
            GetComponent<MeshRenderer>().enabled = false;
        }    


    }
}
