using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieChecker : MonoBehaviour
{

    public bool over;
    public float sizeX = 5;

    public float sizeZ = 5;
    public float sizeY = 5;
    public LayerMask layer;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 255, 255, .1f);

        //if (!GameObject.Find("generator").GetComponent<InsideGenV2>().debugging)
        //{
            Gizmos.DrawCube(transform.position, new Vector3(sizeX, sizeY, sizeZ));
        //}

    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public bool EnemiesInArea()
    {

        


        Debug.Log("method working");
        return Physics.CheckBox(transform.position, new Vector3(sizeX / 2, 100, sizeZ / 2), Quaternion.identity, layer);
    }
}
