using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Proyecto26;
using UnityEngine.SceneManagement;


public class Stacking_level_2 : MonoBehaviour
{
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;
    // private string[] orderSequence = {"YellowCube","GreenCube","YellowCube","RedCube"};
    public TextMeshProUGUI cubeElement;

    public List<GameObject> _cubeList = new List<GameObject>();
    private int _cubeListIndexCounter = 0;
    Collider m_Collider;
    public GameObject head;
    public Transform bridgeEnd;
    public Transform bridgeItemPrefab;
    public float bridgeOffset = 1.7f;
    public float normalRespawnTime = 10.0f;
    public Transform yellowCubePrefab;
    public Transform redCubeAndTextPrefab;
    public Transform greenCubeAndTextPrefab;
    public GameObject monster;
    public float powerUprespawnTime = 15.0f;
    private int monsterPlatformCount = 0;
    public int totalPlatformsNeeded = 2;
    public Transform foodPrefab;
    public Transform foodPlatform;
    private Transform food;
    private bool isFoodPresent = false;
    private bool foodCollected = false;
    public TextMeshProUGUI gameProgress;
    public TextMeshProUGUI foodAvailable;
    
    private int totalNumberOfJumps;

    void Start(){
        TimeElapsed.resetStopwatch();
        TimeElapsed.startTime();
    }

    private IEnumerator respawnCube(string cubeType, Transform cubeParent){

        float rTime = normalRespawnTime;

        if(cubeType == "FreezePrefab" || cubeType == "JumpPrefab"){
            rTime = powerUprespawnTime;
        }
        
        yield return new WaitForSeconds(rTime);

        Vector3 temp = cubeParent.position;
        temp.y += 0.8f;
        Vector3 respawnPosition = temp;

        switch(cubeType){
            case "YellowCube":
            Instantiate(yellowCubePrefab, respawnPosition, cubeParent.rotation, cubeParent);
            break;

            case "JumpPrefab":
            {
                //Debug.Log("in switch");
                Instantiate(greenCubeAndTextPrefab, respawnPosition, cubeParent.rotation, cubeParent);
                break;
            }
            

            case "FreezePrefab":
            Instantiate(redCubeAndTextPrefab, respawnPosition, cubeParent.rotation, cubeParent);
            break;
        }
    }

    public int getTotalNumberOfJumps() {
        return totalNumberOfJumps;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "YellowCube"){
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            _cubeList.Add(other.gameObject);
            // if (_cubeList.Count==1)
            // {
            //     other.gameObject.transform.position = head.transform.position;
            //     _currentCubePos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
            //     other.gameObject.GetComponent<Cube>().UpdateCubePosition(head.transform, true);
            // }
            // else if (_cubeList.Count > 1)
            // {
            //     other.gameObject.transform.position = _currentCubePos;
            //     _currentCubePos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 0.3f, other.transform.position.z);
            //     other.gameObject.GetComponent<Cube>().UpdateCubePosition(_cubeList[_cubeListIndexCounter].transform, true);
            //     _cubeListIndexCounter++;
            // }
            makeBridgeToMonster();

            //Old Code
            // gameObject.GetComponent<NatkhatCubes>().funWithCube(other.gameObject);
            // cubeElement.text = (8-_cubeList.Count).ToString() + " cubes remaining";

            // if (_cubeList.Count == 8){
            //     TimeElapsed.endTime();
            //     Level level = new Level(true, TimeElapsed._stopWatch.ElapsedMilliseconds, _cubeList.Count);
            //     RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/0/.json", level);
            //     // UnityEditor.EditorApplication.isPlaying = false;
            //     // Application.Quit();
            //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // }
        }
        else if(other.tag == "JumpPrefab"){
            totalNumberOfJumps++;
            //Debug.Log("in on trigger");
            Destroy(other.gameObject);
            //Debug.Log(other);
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            gameObject.GetComponent<NatkhatCubes_L2>().funWithCube(3);
        }
        else if(other.tag == "FreezePrefab"){
            Destroy(other.gameObject);
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            monster.GetComponent<EnemyShooter>().freezeProjectile();
        }
        else if(other.tag == "Food"){
            emptyPlayerStack();
            other.gameObject.transform.position = head.transform.position;
            _currentCubePos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
            other.gameObject.GetComponent<Cube>().UpdateCubePosition(head.transform, true);
            foodCollected = true;
        }
    }

    private void stackOnPlayer(){
        
    }

    public void emptyPlayerStack(){
        // Debug.Log("Inside Empty Stack");
        foreach(GameObject currentStackItem in _cubeList){
            Destroy(currentStackItem);
        }
        _cubeList.Clear();
        _firstCubePos = Vector3.zero;
        _currentCubePos = Vector3.zero;
        _cubeListIndexCounter = 0;

        // if(foodCollected){
        //     Destroy(foodPlatform.GetChild(0).gameObject);
        //     isFoodPresent = false;
        //     foodCollected = false;
        //     spawnFoodItem();
        // }

    }

    public void makeBridgeToMonster(){
        if(monsterPlatformCount <= totalPlatformsNeeded){
            foreach(GameObject currentStackItem in _cubeList){
                if(monsterPlatformCount >= totalPlatformsNeeded){
                    break;
                }
                else{
                    Instantiate(bridgeItemPrefab, bridgeEnd.position, bridgeEnd.rotation);
                    Vector3 temp = bridgeEnd.position;
                    temp.x += bridgeOffset;
                    bridgeEnd.position = temp;
                    monsterPlatformCount += 1;
                }
        }
        }
        emptyPlayerStack();

        if(monsterPlatformCount == totalPlatformsNeeded){
            // spawnFoodItem();
            // foodAvailable.text = "Food available to feed the monster!";
        }

        gameProgress.text = monsterPlatformCount + "/2 Yellow Cubes Collected";
    }

    private void spawnFoodItem(){
        if(!isFoodPresent){
            Vector3 temp = foodPlatform.position;
            temp.y += 1.0f;
            Vector3 respawnPosition = temp;
            food = Instantiate(foodPrefab, respawnPosition, foodPlatform.rotation);
            food.parent = foodPlatform;
            isFoodPresent = true;
        }
    }

    public void checkEndCondition(){
        if(true){
            TimeElapsed.endTime();
            int totalNumberOfFalls = gameObject.GetComponent<Player_Movement_L2>().getTotalNumberOfFalls();
            // float totalTimeTaken = TimeElapsed._stopWatch.ElapsedMilliseconds + (5000.0f*totalNumberOfFalls) + (5000.0f*totalNumberOfHits);
            // List<List<float>> hitLocations = gameObject.GetComponent<Player_Movement_Level3>().getHitLocations();
            // string hitLocationsString = Level_4.formatHitLocations(hitLocations);
            string fallLocation = gameObject.GetComponent<Player_Movement_L2>().getFallLocations();
            Level_2 level_2 = new Level_2(getTotalNumberOfJumps(), totalNumberOfFalls, TimeElapsed._stopWatch.ElapsedMilliseconds, true,fallLocation);
            RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/2/.json",level_2);
            //Level level = new Level(true, TimeElapsed._stopWatch.ElapsedMilliseconds);
            //RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/0/.json",level);
            //Debug.Log("Food Fed");
            // gameObject.GetComponent<PanelSwitcher_L2>().switchpanel();
        }
    }
}
