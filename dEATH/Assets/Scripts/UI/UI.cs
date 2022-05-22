using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    private stats sts;
    public Slider healthSlider;
    public Slider staminaSlider;
    // Start is called before the first frame update
    void Start()
    {
        sts = GameObject.FindGameObjectWithTag("Player").GetComponent<stats>();
        healthSlider.maxValue = sts.health;
        staminaSlider.maxValue = sts.stamina;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = sts.health;
        staminaSlider.value = sts.stamina;
    }
}
