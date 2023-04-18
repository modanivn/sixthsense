using UnityEngine;
using TMPro;
using Proyecto26;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] GameObject EndGameCanvas;
    public float timer = 420.0f;
    public float popUpTime = 2.0f;
    private bool switchStarted = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI Penalty;
    public TextMeshProUGUI PlusTime;
    public Image PlusTimeImage;
    public Image PenaltyImage;

    void Start(){
        TimeElapsed.resetStopwatch();
        TimeElapsed.startTime();
        PenaltyImage.enabled = false;
        // PlusTimeImage.enabled = false;

        // Check if PlusTimeImage and PlusTime text are not null, then enable them
        if (PlusTimeImage != null && PlusTime != null) {
            PlusTimeImage.enabled = false;
        }
    }

    void Update()
    {
        if (!switchStarted)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if (timer <= 0)
            {
                TimeElapsed.endTime();
                int totalNumberOfJumps = gameObject.GetComponent<CubeLogic>().getTotalNumberOfJumps();
                int totalNumberOfFreeze = gameObject.GetComponent<CubeLogic>().getTotalNumberOfFreeze();
                int totalNumberOfFalls = gameObject.GetComponent<Player_Movement>().getTotalNumberOfFalls();
                int totalNumberOfHits = gameObject.GetComponent<Player_Movement>().getTotalNumberOfHits();
                List<List<float>> hitLocations = gameObject.GetComponent<Player_Movement>().getHitLocations();
                float totalTimeTaken = TimeElapsed._stopWatch.ElapsedMilliseconds + (5000.0f*totalNumberOfFalls) + (5000.0f*totalNumberOfHits);
                string hitLocationsString = LevelAnalytics.formatHitLocations(hitLocations);
                string fallLocation = gameObject.GetComponent<Player_Movement>().getFallLocations();
                int bulletsShot = gameObject.GetComponent<ShootingScript>().getBulletsShot();
                LevelAnalytics levelAnalytics = new LevelAnalytics(totalNumberOfJumps, totalNumberOfFreeze, totalNumberOfHits, totalNumberOfFalls, TimeElapsed._stopWatch.ElapsedMilliseconds, false, hitLocationsString, fallLocation, bulletsShot);
                RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/4/.json",levelAnalytics);
                switchpanel();
            }
        }
    }

    public void reduceTime(){
        timer -= 5.0f;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        InvokeRepeating("Countdown",0.0f,1.0f);
    }

    public void increaseTimePowerup(){
        timer += 10.0f;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        // InvokeRepeating("UpCountdown",0.0f,1.0f);

        if (PlusTimeImage != null && PlusTime != null) {
            InvokeRepeating("UpCountdown", 0.0f, 1.0f);
        }
    }

    void UpCountdown(){

        PlusTime.text = "+10";
        // PlusTimeImage.enabled = true;

        if (PlusTimeImage != null) {
            PlusTimeImage.enabled = true;
        }

        popUpTime -= 1.0f;
        if(popUpTime<=0f){
            popUpTime = 2.0f;
            CancelInvoke("UpCountdown");
            PlusTime.text = "";
            // PlusTimeImage.enabled = false;

            if (PlusTimeImage != null && PlusTime != null) {
                PlusTimeImage.enabled = false;
            }
        }
    }

    void Countdown(){

        Penalty.text = "-5";
        PenaltyImage.enabled = true;
        popUpTime -= 1.0f;
        if(popUpTime<=0f){
            popUpTime = 2.0f;
            CancelInvoke("Countdown");
            Penalty.text = "";
            PenaltyImage.enabled = false;
        }
    }

    public void switchpanel(){
        switchStarted = true;
        EndGameCanvas.SetActive(true);
    }
}
