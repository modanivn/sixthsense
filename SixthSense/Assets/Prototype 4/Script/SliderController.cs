using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public float sensitivity; // the public variable you want to control with the slider
    public Slider slider; // the slider game object
    public GameObject player;

    void Start()
    {
        // Set the minimum and maximum values of the slider to match the range of values for your public variable
        slider.minValue = 0f;
        slider.maxValue = 100f;
    }

    public void UpdateSensitivity()
    {
        // This function will be called whenever the slider value changes
        // It will set the value of the public variable to the slider value
        sensitivity = slider.value;
        player.GetComponent<Player_Movement>().UpdateSensitivity(sensitivity);
    }
}
