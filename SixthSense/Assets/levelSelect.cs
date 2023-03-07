using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour
{

    public void openLevel1() {
        SceneManager.LoadScene(2);
    }

    public void openLevel2() {
        SceneManager.LoadScene(3);
    }

    public void openLevel3() {
        SceneManager.LoadScene(4);
    }

    public void openLevel4() {
        SceneManager.LoadScene(5);
    }

}
