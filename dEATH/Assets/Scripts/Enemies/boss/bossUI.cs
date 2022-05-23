using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bossUI : MonoBehaviour
{

    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = GameObject.Find("cerberus").GetComponent<cerberus>().health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameObject.Find("cerberus").GetComponent<cerberus>().health;
    }
}
