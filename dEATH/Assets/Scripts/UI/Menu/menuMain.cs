using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMain : MonoBehaviour
{

    public GameObject loading;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void loadPlay()
    {
        loading.SetActive(true);
        StartCoroutine(loadingS());
    }


    IEnumerator loadingS()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(3);
    }


}
