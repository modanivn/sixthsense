using UnityEngine;
using TMPro;
using Proyecto26;

public class PanelSwitcher : MonoBehaviour
{
    //public float switchTime = 0f;
    public CanvasGroup fromPanel;
    public CanvasGroup toPanel;
    public float timer = 60.0f;
    public float popUpTime = 2.0f;

    //private float timer = 0f;
    private bool switchStarted = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI Penalty;

    void Start(){
        TimeElapsed.startTime();
    }

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

            // if(popUpTime<=0){
            // popUpTime = 2.5f;
            // CancelInvoke("Countdown");
            // Penalty.text = "";
            // }
            if (timer <= 0)
            {
                TimeElapsed.endTime();
                int totalNumberOfJumps = gameObject.GetComponent<StackingPrototype3>().getTotalNumberOfJumps();
                int totalNumberOfFreeze = gameObject.GetComponent<StackingPrototype3>().getTotalNumberOfFreeze();
                int totalNumberOfHits = gameObject.GetComponent<Player_Movement>().getTotalNumberOfHits();
                Level level = new Level(totalNumberOfJumps, totalNumberOfFreeze, totalNumberOfHits, TimeElapsed._stopWatch.ElapsedMilliseconds, false);
                RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/4/.json",level);
                switchpanel();


            }
        }
    }

    public void reduceTime(){
        // Debug.Log("Before update timer value : "  + timer);
        timer -= 5.0f;
        // Debug.Log("method called : "  + timer);
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = "Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        InvokeRepeating("Countdown",0.0f,1.0f);
        // if(popUpTime<=0f){
        //     popUpTime = 3.0f;
        //     CancelInvoke("Countdown");
        //     Penalty.text = "";
        // }
    }

    void Countdown(){

        Penalty.text = "-5 seconds";
        popUpTime -= 1.0f;
        //Debug.Log(popUpTime);
        if(popUpTime<=0f){
            popUpTime = 2.0f;
            CancelInvoke("Countdown");
            Penalty.text = "";
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
