using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overlaping1 : MonoBehaviour
{

    public bool over;
    public float sizeX = 5;

    public float sizeZ = 5;
    public LayerMask layer;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        over = Physics.CheckBox(transform.GetChild(0).transform.GetChild(transform.GetChild(0).transform.childCount - 1).transform.position, new Vector3(sizeX / 2, 100, sizeZ / 2), Quaternion.identity, layer);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);

        if (!GameObject.Find("generator").GetComponent<InsideGenV2>().debugging)
        {
            Gizmos.DrawCube(transform.GetChild(0).transform.GetChild(transform.GetChild(0).transform.childCount - 1).transform.position, new Vector3(sizeX, 100, sizeZ));
        }

    }


    public bool over2()
    {

        //GameObject[] rooms = GameObject.Find("generator").GetComponent<insideGenV2>().roomsPlaced;


        //foreach(GameObject roo in rooms)
        //{

        //}


        Debug.Log("method working");
        return Physics.CheckBox(transform.GetChild(0).transform.GetChild(transform.GetChild(0).transform.childCount - 1).transform.position, new Vector3(sizeX / 2, 100, sizeZ / 2), Quaternion.identity, layer);
    }
}
