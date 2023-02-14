using UnityEngine;
using TMPro;

public class PanelSwitcher : MonoBehaviour
{
    //public float switchTime = 0f;
    public CanvasGroup fromPanel;
    public CanvasGroup toPanel;
    public float timer = 60.0f;

    //private float timer = 0f;
    private bool switchStarted = false;
    public TextMeshProUGUI timerText;


    void Update()
    {
        if (!switchStarted)
        {
            //timer += Time.deltaTime;
            timer -= Time.deltaTime;
            //timerText.text = "Time left: " + Mathf.RoundToInt(timer);
        
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = "Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds);

            if (timer <= 0)
            {
                switchpanel();
            }
        }
    }

    public void switchpanel(){
        switchStarted = true;
        fromPanel.alpha = 0f;
        fromPanel.interactable = false;
        fromPanel.blocksRaycasts = false;
        toPanel.alpha = 1f;
        toPanel.interactable = true;
        toPanel.blocksRaycasts = true;
    }
}
