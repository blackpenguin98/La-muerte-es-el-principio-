using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Bote : MonoBehaviour
{
    CinemachineFreeLook CPrincipal;
    public CinemachineVirtualCamera CBote;
    GameObject Player;

    GameObject canvas1, canvas2;

    AudioSource track1;
    
    // Start is called before the first frame update
    void Start()
    {
        CPrincipal = GameObject.Find("CM FreeLook1").GetComponent<CinemachineFreeLook>();
        CPrincipal.Priority = 0;
        CBote.Priority = 10;

        Player = GameObject.Find("Player");
        Player.SetActive(false);
        canvas1 = GameObject.Find("Canvas1");
        canvas2 = GameObject.Find("Canvas2");
        track1 = GameObject.Find("Track_1").GetComponent<AudioSource>();


        canvas1.SetActive(false);

        StartCoroutine(wait());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reactivate()
    {
        Player.SetActive(true);
        CPrincipal.Priority = 20;
        canvas1.SetActive(true);
        
        Destroy(gameObject);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        track1.Play();
        yield return new WaitForSeconds(4);
        
        canvas2.SetActive(false);
        

    }

}
