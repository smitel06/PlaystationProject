using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthValue : MonoBehaviour
{
    //controls health value next to player healthbar on hud

    //variables
    [SerializeField] TextMeshProUGUI healthDisplay;
    [SerializeField] Slider healthSlider;
    
        

    private void Update()
    {
        //set health value to the text mesh pro using slider values
        healthDisplay.text = healthSlider.value + "/" + healthSlider.maxValue;
    }
}
