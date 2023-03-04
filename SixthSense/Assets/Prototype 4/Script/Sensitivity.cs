using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    public Slider slider; // the slider game object
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // Set the minimum and maximum values of the slider to match the range of values for your public variable
        slider.minValue = 0f;
        slider.maxValue = 100f;
    }

    // Update is called once per frame
    public void UpdateSensitivity()
    {
        // player.GetComponent<Player_Movement>().UpdateSensitivity(slider.value);
        Debug.Log("first sensitivity: " + PlayerPrefs.GetFloat("sensitivity"));
        PlayerPrefs.SetFloat("sensitivity", slider.value);
        Debug.Log("second sensitivity: " + PlayerPrefs.GetFloat("sensitivity"));
    }

    
}
