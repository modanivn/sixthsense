using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public float switchTime = 5f;
    public CanvasGroup fromPanel;
    public CanvasGroup toPanel;

    private float timer = 0f;
    private bool switchStarted = false;

    void Update()
    {
        if (!switchStarted)
        {
            timer += Time.deltaTime;

            if (timer >= switchTime)
            {
                switchStarted = true;
                fromPanel.alpha = 0f;
                fromPanel.interactable = false;
                fromPanel.blocksRaycasts = false;
                toPanel.alpha = 1f;
                toPanel.interactable = true;
                toPanel.blocksRaycasts = true;
            }
        }
    }
}
