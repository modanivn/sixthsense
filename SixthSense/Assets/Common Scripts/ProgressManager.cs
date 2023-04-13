using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressManager : MonoBehaviour
{
    // public Image[] cubeImages;
    // public Sprite solidCube;

    public Slider progressSlider;


    private int cubesCollected = 0;
    public int totalCubes;
    
    // Start is called before the first frame update
    void Start()
    {
            progressSlider = GameObject.Find("ProgressSlider").GetComponent<Slider>();
            progressSlider.maxValue = totalCubes;
            progressSlider.value = 0;
       
    }

    public void CollectCube()
    {
        cubesCollected++;
        
        float fillAmount = (float)(cubesCollected / progressSlider.maxValue) * totalCubes;
        progressSlider.value = fillAmount;
        if(cubesCollected == totalCubes) {
            progressSlider.fillRect.GetComponent<Image>().color = Color.green;
        }
        if(cubesCollected < totalCubes) {
            progressSlider.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
