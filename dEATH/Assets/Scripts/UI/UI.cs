using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    private stats sts;
    public Slider healthSlider; 
    // Start is called before the first frame update
    void Start()
    {
        sts = GameObject.FindGameObjectWithTag("Player").GetComponent<stats>();
        healthSlider.maxValue = sts.health;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = sts.health;
    }
}
