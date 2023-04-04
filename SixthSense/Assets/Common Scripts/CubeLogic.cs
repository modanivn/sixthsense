using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Proyecto26;
using UnityEngine.SceneManagement;
using System.Linq;

public class CubeLogic : MonoBehaviour
{
    public Transform bridgeItemPrefab;
    public float bridgeOffset = 1.7f;
    public float normalRespawnTime = 10.0f;
    public Transform yellowCubePrefab;
    public Transform redCubeAndTextPrefab;
    public Transform bulletPrefab;
    public Transform greenCubeAndTextPrefab;
    public GameObject monster;
    public float powerUprespawnTime = 15.0f;
    private int monsterPlatformCount = 0;
    public int totalPlatformsNeeded = 4;
    public TextMeshProUGUI gameProgress;
    private int totalNumberOfFreeze;
    private int totalNumberOfJumps;
    public GameObject[] platforms;
    [SerializeField] List<Transform> activeCubes = new List<Transform>();

    void Start(){
        TimeElapsed.resetStopwatch();
        TimeElapsed.startTime();
    }

    public IEnumerator respawnCube(string cubeType, Transform cubeParent){

        float rTime = normalRespawnTime;

        if(cubeType == "FreezePrefab" || cubeType == "JumpPrefab" || cubeType == "Bullet"){
            rTime = powerUprespawnTime;
        }
        
        yield return new WaitForSeconds(rTime);

        Vector3 temp = cubeParent.position;
        
        if(cubeType == "Bullet"){
            temp.y += 0.4f;
        }
        else{
            temp.y += 0.8f;
        }
        Vector3 respawnPosition = temp;

        switch(cubeType){
            case "YellowCube":
            Transform clone = Instantiate(yellowCubePrefab, respawnPosition, cubeParent.rotation, cubeParent);
            activeCubes.Add(clone);
            break;

            case "JumpPrefab":
            {
                Instantiate(greenCubeAndTextPrefab, respawnPosition, cubeParent.rotation, cubeParent);
                break;
            }

            case "FreezePrefab":
            Instantiate(redCubeAndTextPrefab, respawnPosition, cubeParent.rotation, cubeParent);
            break;

            case "Bullet":
            Instantiate(bulletPrefab, respawnPosition, cubeParent.rotation, cubeParent);
            break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "YellowCube"){
            activeCubes.Remove(other.gameObject.transform);
            Destroy(other.gameObject);
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            makeBridgeToMonster();
        }
        else if(other.tag == "JumpPrefab"){
            totalNumberOfJumps++;
            Destroy(other.gameObject);
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            gameObject.GetComponent<NatkhatCubes>().funWithCube(3);
        }

        else if(other.tag == "Bullet"){
            Destroy(other.gameObject);
            StartCoroutine(respawnCube(other.tag,other.transform.parent)); 
        }


        else if(other.tag == "FreezePrefab"){
            totalNumberOfFreeze++;
            Destroy(other.gameObject);
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            monster.GetComponent<EnemyShooter>().freezeProjectile();
        }
    }

    public int getTotalNumberOfFreeze() {
        return totalNumberOfFreeze;
    }

    public int getTotalNumberOfJumps() {
        return totalNumberOfJumps;
    }

    public void makeBridgeToMonster(){
        if(monsterPlatformCount < totalPlatformsNeeded){
            Vector3 position = platforms[monsterPlatformCount].transform.position;
            Instantiate(bridgeItemPrefab, position, Quaternion.identity);
            monsterPlatformCount += 1;
        }
        gameProgress.text = monsterPlatformCount + "/4 Bridge Formed!";
    }

    public void checkEndCondition(){
        if(true){
            TimeElapsed.endTime();
            int totalNumberOfHits = gameObject.GetComponent<Player_Movement>().getTotalNumberOfHits();
            int totalNumberOfFalls = gameObject.GetComponent<Player_Movement>().getTotalNumberOfFalls();
            float totalTimeTaken = TimeElapsed._stopWatch.ElapsedMilliseconds + (5000.0f*totalNumberOfFalls) + (5000.0f*totalNumberOfHits);
            List<List<float>> hitLocations = gameObject.GetComponent<Player_Movement>().getHitLocations();
            string hitLocationsString = Level_4.formatHitLocations(hitLocations);
            string fallLocation = gameObject.GetComponent<Player_Movement>().getFallLocations();
            int bulletsShot = gameObject.GetComponent<ShootingScript>().getBulletsShot();
            Level_4 level_4 = new Level_4(getTotalNumberOfJumps(), getTotalNumberOfFreeze(), totalNumberOfHits, totalNumberOfFalls, TimeElapsed._stopWatch.ElapsedMilliseconds, true, hitLocationsString, fallLocation, bulletsShot);
            RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/4/.json",level_4);
        }
    }

    public List<Transform> getActiveCubes(){
        return activeCubes;
    }

    public void removeFromActiveCubes(Transform eatenCube){
        activeCubes.remove(eatenCube)
    }
}
