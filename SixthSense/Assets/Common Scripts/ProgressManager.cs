using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressManager : MonoBehaviour
{
    public Image[] cubeImages;
    public Sprite solidCube;



    private int cubesCollected = 0;
    public int totalCubes;
    
    // Start is called before the first frame update
    void Start()
    {
       
         foreach (Image cubeImage in cubeImages)
        {
            cubeImage.color = new Color(1f, 1f, 1f, 0.5f); // Set each cube to be translucent
        }
    }

    public void CollectCube()
    {
        cubesCollected++;
        if (cubesCollected <= totalCubes)
        {
            for (int i = 0; i < cubesCollected; i++)
            {
                cubeImages[i].sprite = solidCube; // Set the Image components to be solid up to the number of cubes collected
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
