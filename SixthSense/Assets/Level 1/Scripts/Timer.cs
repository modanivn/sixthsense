using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;
    public int Duration;
    private int remainingDuration;
    
    private void Start ()
    {
        Being(Duration);
    }
    
    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >=0)
        {
            uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            Debug.Log("Inside UpdateTimer: " + remainingDuration);
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        print("End");
        gameObject.GetComponent<PanelSwitcher>().switchpanel();
    }

    public void reduceTime()
    {
        remainingDuration -= 5;
        Debug.Log("Inside ReduceTime: " + remainingDuration);
        uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
        uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
        remainingDuration--;
        // StopCoroutine(UpdateTimer());
        // Being(remainingDuration);
    }

}