using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InsideGenV2 : MonoBehaviour
{

    public GameObject[] rooms;
    public GameObject holder;
    public GameObject[] roomsPlaced = new GameObject[2000];
    public GameObject[] roomsPlaced2 = new GameObject[2000];
    public bool debugging = false;
    public int roomsToPlace = 10;
    public int seed;
    public int roomsPlacedActually = 0;


    public int missingRooms = 0;

    bool destroyed = false;

    List<GameObject> entries = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (!debugging)
        {
            //seed = GameManager.instance.insideSeedEnemy;
        }

        seed = Random.Range(0, 200000000);


        Random.InitState(seed);

        roomsPlaced[0] = Instantiate(rooms[0], transform.position, transform.rotation);
        roomsPlaced[0].transform.GetChild(0).gameObject.SetActive(true);
        roomsPlaced[0].layer = 12;
        roomsPlacedActually++;
        for (int p = 0; p < roomsPlaced[0].transform.transform.GetChild(0).childCount - 1; p++)
        {


            for (int r = 0; r < roomsPlaced[0].transform.GetChild(0).transform.GetChild(p).childCount; r++)
            {
                for (int v = 0; v < roomsPlaced[0].transform.GetChild(0).transform.GetChild(p).transform.GetChild(r).childCount; v++)
                {



                    //if (roomsPlaced[0].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.name == "floor") { continue; }
                    roomsPlaced[0].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.layer = 12;
                }
            }

        }


        roomsPlaced[0].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

        for (int i = 1; i < roomsToPlace; i += 0)
        {

            if (roomsPlacedActually + missingRooms > roomsToPlace)
            {
                i = 10000;
                break;
            }


            entries = new List<GameObject>();


            for (int e = 0; e < roomsPlaced[i - 1].transform.GetChild(0).transform.childCount - 1; e++)
            {

                entries.Add(roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(e).gameObject);
            }

            Debug.Log(entries.Count + " entries in " + i);


            int entryRoom = Random.Range(0, entries.Count);

            Debug.Log(entryRoom + " random");

            if (i < roomsToPlace)
            {
                int randomRomm = Random.Range(1, rooms.Length - 1);
                Debug.Log(i + "once");
                roomsPlaced[i] = Instantiate(rooms[randomRomm], transform.position, Quaternion.identity);
                roomsPlaced[i].transform.GetChild(0).transform.rotation = roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).transform.rotation;
                Debug.Log(i + "twice");
                roomsPlaced[i].transform.GetChild(0).transform.position = roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).transform.position;
                roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).gameObject.GetComponent<openEntry>().openEnty = false;
                roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).gameObject.tag = "Untagged";
                Debug.Log(i + "thrid");
                roomsPlaced[i].GetComponent<overlaping1>().id = i;
                //roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).gameObject.SetActive(true);

                roomsPlaced[i].transform.GetChild(0).gameObject.SetActive(true);
                roomsPlaced[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);


                //foreach(GameObject toActive in roomsPlaced)
                //{
                //    toActive.transform.GetChild(0).gameObject.SetActive(true);
                //    toActive.transform.GetChild(0).transform.GetChild(entryRoom).gameObject.SetActive(true);
                //}



                Debug.Log(roomsPlaced[i].GetComponent<overlaping1>().over2());

                if (roomsPlaced[i].GetComponent<overlaping1>().over2())
                {

                    Destroy(roomsPlaced[i].gameObject);


                    if (entries.Count < 2)
                    {
                        i--;
                    }


                    missingRooms++;


                }
                else
                {
                    roomsPlaced[i].layer = 12;

                    for (int p = 0; p < roomsPlaced[i].transform.transform.GetChild(0).childCount - 1; p++)
                    {


                        for (int r = 0; r < roomsPlaced[i].transform.GetChild(0).transform.GetChild(p).childCount; r++)
                        {
                            for (int v = 0; v < roomsPlaced[i].transform.GetChild(0).transform.GetChild(p).transform.GetChild(r).childCount; v++)
                            {



                                //if (roomsPlaced[i].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.name == "floor") { continue; }
                                roomsPlaced[i].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.layer = 12;
                            }
                        }

                    }

                    GameObject[] colliders = GameObject.FindGameObjectsWithTag("collider");

                    foreach (GameObject collider in colliders)
                    {
                        collider.layer = 12;
                    }


                    roomsPlacedActually++;

                }






                if (entries.Count >= 2)
                {

                    if (entryRoom == 0)
                    {
                        entryRoom = 1;
                    }
                    else if (entryRoom == 1)
                    {
                        entryRoom = 0;
                    }


                    int randomRomm2 = Random.Range(1, rooms.Length - 1);
                    roomsPlaced[i + 1] = Instantiate(rooms[randomRomm2], transform.position, Quaternion.identity);
                    roomsPlaced[i + 1].transform.GetChild(0).transform.rotation = roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).transform.rotation;
                    roomsPlaced[i + 1].transform.GetChild(0).transform.position = roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).transform.position;


                    roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).gameObject.GetComponent<openEntry>().openEnty = false;
                    roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).gameObject.tag = "Untagged";
                    //roomsPlaced[i - 1].transform.GetChild(0).transform.GetChild(entryRoom).gameObject.SetActive(true);

                    roomsPlaced[i + 1].transform.GetChild(0).gameObject.SetActive(true);
                    roomsPlaced[i + 1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    //foreach (GameObject toActive in roomsPlaced)
                    //{
                    //    toActive.transform.GetChild(0).gameObject.SetActive(true);
                    //    toActive.transform.GetChild(0).transform.GetChild(entryRoom).gameObject.SetActive(true);
                    //}

                    Debug.Log(roomsPlaced[i + 1].GetComponent<overlaping1>().over2() + " room ");

                    roomsPlaced[i + 1].GetComponent<overlaping1>().id = i + 1;
                    if (roomsPlaced[i + 1].GetComponent<overlaping1>().over2())
                    {

                        Destroy(roomsPlaced[i + 1].gameObject);
                        i--;

                        destroyed = true;
                        missingRooms++;
                    }
                    else
                    {
                        roomsPlaced[i + 1].layer = 12;

                        for (int p = 0; p < roomsPlaced[i].transform.transform.GetChild(0).childCount - 1; p++)
                        {


                            for (int r = 0; r < roomsPlaced[i].transform.GetChild(0).transform.GetChild(p).childCount; r++)
                            {
                                for (int v = 0; v < roomsPlaced[i].transform.GetChild(0).transform.GetChild(p).transform.GetChild(r).childCount; v++)
                                {



                                    //if (roomsPlaced[i].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.name == "floor") { continue; }
                                    roomsPlaced[i].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.layer = 12;
                                }
                            }

                        }

                        GameObject[] colliders = GameObject.FindGameObjectsWithTag("collider");

                        foreach (GameObject collider in colliders)
                        {
                            collider.layer = 12;
                        }


                        roomsPlacedActually++;


                    }









                    i += 2;
                }
                else
                {

                    i++;


                }

            }








        }


        roomsPlaced = new GameObject[0];

        //Make first room


        for (int g = 0; g < 1; g += 0)
        {
            GameObject[] entries = new GameObject[1000];
            entries = GameObject.FindGameObjectsWithTag("enter");

            int randomEntry = Random.Range(0, entries.Length);
            int randomRoom = Random.Range(1, rooms.Length - 1);
            int entryRoom = 0;


            roomsPlaced2[g] = Instantiate(rooms[rooms.Length - 1], transform.position, transform.rotation);
            roomsPlaced2[g].transform.GetChild(0).transform.rotation = entries[randomEntry].transform.rotation;
            roomsPlaced2[g].transform.GetChild(0).transform.position = entries[randomEntry].transform.position;

            roomsPlaced2[g].transform.GetChild(0).gameObject.SetActive(true);
            roomsPlaced2[g].transform.GetChild(0).transform.GetChild(entryRoom).gameObject.SetActive(true);
            roomsPlaced2[g].GetComponent<overlaping1>().id = g;


            if (roomsPlaced2[g].GetComponent<overlaping1>().over2())
            {

                Destroy(roomsPlaced2[g].gameObject);
                continue;


            }
            else
            {
                entries[randomEntry].tag = "Untagged";
                roomsPlaced2[g].layer = 12;

                for (int p = 0; p < roomsPlaced2[g].transform.transform.GetChild(0).childCount - 1; p++)
                {


                    for (int r = 0; r < roomsPlaced2[g].transform.GetChild(0).transform.GetChild(p).childCount; r++)
                    {
                        for (int v = 0; v < roomsPlaced2[g].transform.GetChild(0).transform.GetChild(p).transform.GetChild(r).childCount; v++)
                        {



                            //if (roomsPlaced[0].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.name == "floor") { continue; }
                            roomsPlaced2[g].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.layer = 12;
                        }
                    }

                }


                GameObject[] colliders = GameObject.FindGameObjectsWithTag("collider");

                foreach (GameObject collider in colliders)
                {
                    collider.layer = 12;
                }


                roomsPlacedActually++;
                g++;
            }

            //g = 2000;

        }





        //make new rooms


        for (int g = 0; g < missingRooms - 2; g += 0)
        {

            GameObject[] entries = new GameObject[1000];
            entries = GameObject.FindGameObjectsWithTag("enter");

            int randomEntry = Random.Range(0, entries.Length);
            int randomRoom = Random.Range(1, rooms.Length - 1);
            int entryRoom = 0;


            roomsPlaced2[g] = Instantiate(rooms[randomRoom], transform.position, transform.rotation);
            roomsPlaced2[g].transform.GetChild(0).transform.rotation = entries[randomEntry].transform.rotation;
            roomsPlaced2[g].transform.GetChild(0).transform.position = entries[randomEntry].transform.position;

            roomsPlaced2[g].transform.GetChild(0).gameObject.SetActive(true);
            roomsPlaced2[g].transform.GetChild(0).transform.GetChild(entryRoom).gameObject.SetActive(true);
            roomsPlaced2[g].GetComponent<overlaping1>().id = g;





            if (roomsPlaced2[g].GetComponent<overlaping1>().over2())
            {

                Destroy(roomsPlaced2[g].gameObject);
                continue;


            }
            else
            {
                entries[randomEntry].tag = "Untagged";
                roomsPlaced2[g].layer = 12;

                for (int p = 0; p < roomsPlaced2[g].transform.transform.GetChild(0).childCount - 1; p++)
                {


                    for (int r = 0; r < roomsPlaced2[g].transform.GetChild(0).transform.GetChild(p).childCount; r++)
                    {
                        for (int v = 0; v < roomsPlaced2[g].transform.GetChild(0).transform.GetChild(p).transform.GetChild(r).childCount; v++)
                        {



                            //if (roomsPlaced[0].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.name == "floor") { continue; }
                            roomsPlaced2[g].transform.transform.GetChild(0).GetChild(p).transform.GetChild(r).transform.GetChild(v).gameObject.layer = 12;
                        }
                    }

                }


                GameObject[] colliders = GameObject.FindGameObjectsWithTag("collider");

                foreach (GameObject collider in colliders)
                {
                    collider.layer = 12;
                }


                roomsPlacedActually++;
                g++;
            }

            //g = 2000;

        }



        //return floor


        GameObject[] roomsFloor = GameObject.FindGameObjectsWithTag("collider");


        foreach (GameObject floor in roomsFloor)
        {
            if (floor.name == "floor")
            {
                floor.layer = 6;

            }
        }





    }


}