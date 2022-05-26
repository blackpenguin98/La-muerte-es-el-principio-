using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuMain : MonoBehaviour
{

    public GameObject loading, setting, menu;
    public Dropdown drop;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(2, true);
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


    public void quitGame()
    {
        Application.Quit();
    }


    public void LoadSettings()
    {
        setting.SetActive(true);
        menu.SetActive(false);
    }

    public void LoadMenu()
    {
        setting.SetActive(false);
        menu.SetActive(true);
    }


    public void changeQuality()
    {
        QualitySettings.SetQualityLevel(drop.value, true);
    }


}
