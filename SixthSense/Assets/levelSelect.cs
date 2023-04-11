using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour
{

    public void openLevel(int level) {
        SceneManager.LoadScene(level);
    }

}
