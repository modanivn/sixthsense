using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public List<GameObject> panels;
    public GameObject player;
    private int currentPanelIndex = 0;

    void Start()
    {
        SetActivePanel(currentPanelIndex);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SetActivePanel(currentPanelIndex + 1);
        }
    }

    void SetActivePanel(int index)
    {
        if (index >= 0 && index < panels.Count)
        {
            panels[currentPanelIndex].SetActive(false);
            panels[index].SetActive(true);
            currentPanelIndex = index;
        }
        if(index == (panels.Count - 1) && !player.activeSelf) {
            player.SetActive(true);
        }
    }
}
