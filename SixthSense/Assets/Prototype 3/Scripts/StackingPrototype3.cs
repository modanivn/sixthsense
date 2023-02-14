using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Proyecto26;
using UnityEngine.SceneManagement;

public class StackingPrototype3 : MonoBehaviour
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
    public Transform redCubePrefab;
    public Transform greenCubePrefab;
    public GameObject monster;
    public float powerUprespawnTime = 15.0f;
    private int monsterPlatformCount = 0;
    public int totalPlatformsNeeded = 4;
    public Transform foodPrefab;
    public Transform foodPlatform;

    private IEnumerator respawnCube(string cubeType, Transform cubeParent){

        float rTime = normalRespawnTime;

        if(cubeType == "RedCube" || cubeType == "GreenCube"){
            rTime = powerUprespawnTime;
        }
        
        yield return new WaitForSeconds(rTime);

        Vector3 temp = cubeParent.position;
        temp.y += 0.4f;
        Vector3 respawnPosition = temp;

        switch(cubeType){
            case "YellowCube":
            Instantiate(yellowCubePrefab, respawnPosition, cubeParent.rotation, cubeParent);
            break;

            case "GreenCube":
            Instantiate(greenCubePrefab, respawnPosition, cubeParent.rotation, cubeParent);
            break;

            case "RedCube":
            Instantiate(redCubePrefab, respawnPosition, cubeParent.rotation, cubeParent);
            break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "YellowCube"){
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            _cubeList.Add(other.gameObject);
            if (_cubeList.Count==1)
            {
                other.gameObject.transform.position = head.transform.position;
                _currentCubePos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<Cube>().UpdateCubePosition(head.transform, true);
            }
            else if (_cubeList.Count > 1)
            {
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<Cube>().UpdateCubePosition(_cubeList[_cubeListIndexCounter].transform, true);
                _cubeListIndexCounter++;
            }
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
        else if(other.tag == "GreenCube"){
            Destroy(other.gameObject);
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            gameObject.GetComponent<NatkhatCubes>().funWithCube(3);
        }
        else if(other.tag == "RedCube"){
            Destroy(other.gameObject);
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            monster.GetComponent<EnemyShooter>().freezeProjectile();
        }
        else if(other.tag == "Food"){
            emptyPlayerStack();
            other.gameObject.transform.position = head.transform.position;
            _currentCubePos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
            other.gameObject.GetComponent<Cube>().UpdateCubePosition(head.transform, true);
        }
    }

    private void stackOnPlayer(){
        
    }

    public void emptyPlayerStack(){
        foreach(GameObject currentStackItem in _cubeList){
            Destroy(currentStackItem);
        }
        _cubeList.Clear();
        _firstCubePos = Vector3.zero;
        _currentCubePos = Vector3.zero;
        _cubeListIndexCounter = 0;
    }

    public void makeBridgeToMonster(){
        if(monsterPlatformCount <= totalPlatformsNeeded){
            foreach(GameObject currentStackItem in _cubeList){
                if(monsterPlatformCount > totalPlatformsNeeded){
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
            spawnFoodItem();
        }

    }

    private void spawnFoodItem(){
        Vector3 temp = foodPlatform.position;
        temp.y += 1.5f;
        Vector3 respawnPosition = temp;
        var food = Instantiate(foodPrefab, respawnPosition, foodPlatform.rotation);
        food.transform.parent = foodPlatform;
    }
}
