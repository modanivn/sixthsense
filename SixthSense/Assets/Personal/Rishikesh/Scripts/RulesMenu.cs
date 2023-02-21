using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesMenu : MonoBehaviour
{
    [SerializeField] GameObject rulesMenu;
    [SerializeField] GameObject pauseMenu;
    public void openPauseMenu() {
        pauseMenu.SetActive(true);
        rulesMenu.SetActive(false);
    }
}