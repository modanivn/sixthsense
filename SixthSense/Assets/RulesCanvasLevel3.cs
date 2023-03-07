using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesCanvasLevel3 : MonoBehaviour
{
    [SerializeField] GameObject NewRulesCanvas;
    [SerializeField] GameObject GameCanvas;
    public void StartGame() {
        NewRulesCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        Time.timeScale = 1f;
    }
}
