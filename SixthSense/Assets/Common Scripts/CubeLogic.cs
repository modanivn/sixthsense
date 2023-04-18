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
    public float normalRespawnTime = 10.0f;
    public Transform yellowCubePrefab;
    public Transform redCubeAndTextPrefab;
    public Transform bulletPrefab;
    public Transform translucentBridgePrefab;
    public Transform ycminimapPrefab;
    public Transform jumpminimapPrefab;
    public Transform bulletminimapPrefab;
    public Transform freezeminimapPrefab;
    public Transform greenCubeAndTextPrefab;
    public Transform TimePrefab;
    private int monsterPlatformCount = 0;
    private int jetpackPlatformCount = 0;
    public float powerUprespawnTime = 15.0f;
    public TextMeshProUGUI gameProgress;
    private int totalNumberOfFreeze;
    private int totalNumberOfJumps;
    public GameObject[] platforms;
    public GameObject[] jetpackplatforms;
    // public Transform yellowSpherePrefab;
    public Transform jetpackbridgeItemPrefab;
    public Transform translucentjetpackBridgePrefab;
    [SerializeField] List<Transform> activeCubes = new List<Transform>();
    [SerializeField] List<Transform> activeSpheres = new List<Transform>();
    [SerializeField] List<GameObject> monsters = new List<GameObject>();


    void Start(){
        TimeElapsed.resetStopwatch();
        TimeElapsed.startTime();
    }

    public IEnumerator respawnCube(string cubeType, Transform cubeParent){

        float rTime = normalRespawnTime;

        if(cubeType == "FreezePrefab" || cubeType == "JumpPrefab" || cubeType == "Bullet" || cubeType == "TimePrefab"){
            rTime = powerUprespawnTime;
        }
        
        yield return new WaitForSeconds(rTime);

        Vector3 temp = cubeParent.position;
        
        if(cubeType == "Bullet"){
            temp.y += 0.4f;
        }
        else if(cubeType!="TimePrefab") {
            temp.y += 0.8f;
        }
        Vector3 respawnPosition = temp;

        switch(cubeType){
            case "YellowCube":
            {
                Transform clone = Instantiate(yellowCubePrefab, respawnPosition, cubeParent.rotation, cubeParent);
                if (ycminimapPrefab!= null){
                    Quaternion rotation = clone.rotation * Quaternion.Euler(90f, 0f, 0f);
                    Instantiate(ycminimapPrefab, clone.position, rotation, clone);
                }
                activeCubes.Add(clone);
                break;
            }


            case "JumpPrefab":
            {
                Transform jumpclone = Instantiate(greenCubeAndTextPrefab, respawnPosition, cubeParent.rotation, cubeParent);
                if (jumpminimapPrefab!= null){
                    Quaternion jrotation = jumpclone.rotation * Quaternion.Euler(90f, 0f, 0f);
                    Instantiate(jumpminimapPrefab, jumpclone.position, jrotation, jumpclone);
                }
                break;
            }

            case "FreezePrefab":
            Transform freezeclone = Instantiate(redCubeAndTextPrefab, respawnPosition, cubeParent.rotation, cubeParent);
            if (freezeminimapPrefab!= null){
                Quaternion frotation = freezeclone.rotation * Quaternion.Euler(90f, 90f, 0f);
                Instantiate(freezeminimapPrefab, freezeclone.position, frotation, freezeclone);
            }

            break;

            case "TimePrefab":
            Instantiate(TimePrefab, respawnPosition, cubeParent.rotation, cubeParent);
            break;

            case "Bullet":
            Transform bulletclone = Instantiate(bulletPrefab, respawnPosition, cubeParent.rotation, cubeParent);
            if (bulletminimapPrefab!= null){
                Quaternion brotation = bulletclone.rotation * Quaternion.Euler(90f, 90f, 0f);
                Instantiate(bulletminimapPrefab, bulletclone.position, brotation, bulletclone);
            }
            break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "YellowCube"){
            gameObject.GetComponent<ProgressManager>().CollectCube();
            activeCubes.Remove(other.gameObject.transform);
            Destroy(other.gameObject);
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            makeBridgeToMonster();
        }
        else if(other.tag == "BlueCylinder"){
            Destroy(other.gameObject);
            makeBridgeToJetpack();
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
            foreach(GameObject monster in monsters){
                if(monster!=null){
                    monster.GetComponent<EnemyShooter>().freezeProjectile();
                    monster.GetComponent<MonsterMovement>().stopMonsterMovement();
                }
            }
        }

        else if(other.tag == "Jetpack"){
            Destroy(other.gameObject);
            gameObject.GetComponent<Player_Movement>().gotJetPack();
        }

        else if(other.tag == "TimePrefab"){
            Destroy(other.gameObject);
            StartCoroutine(respawnCube(other.tag,other.transform.parent));
            gameObject.GetComponent<PanelSwitcher>().increaseTimePowerup();
        }
    }

    public int getTotalNumberOfFreeze() {
        return totalNumberOfFreeze;
    }

    public int getTotalNumberOfJumps() {
        return totalNumberOfJumps;
    }

    public void makeBridgeToMonster(){
        if(monsterPlatformCount < platforms.Length){
            Vector3 position = platforms[monsterPlatformCount].transform.position;
            Instantiate(bridgeItemPrefab, position, Quaternion.identity);
            if (translucentBridgePrefab!= null){
                Instantiate(translucentBridgePrefab, position, Quaternion.Euler(90, 90, 0));
            }
            monsterPlatformCount += 1;
        }
        gameProgress.text = monsterPlatformCount + "/ " + platforms.Length.ToString() +" Bridge Formed!";
    }

    public void makeBridgeToJetpack(){
        if(jetpackPlatformCount < jetpackplatforms.Length){
            Vector3 position = jetpackplatforms[jetpackPlatformCount].transform.position;
            Instantiate(jetpackbridgeItemPrefab, position, Quaternion.identity);
            if (translucentjetpackBridgePrefab!= null){
                Instantiate(translucentjetpackBridgePrefab, position, Quaternion.Euler(90, 90, 0));
            }
            jetpackPlatformCount += 1;
        }
    }

    public void checkEndCondition(){
        if(true){
            TimeElapsed.endTime();
            int totalNumberOfHits = gameObject.GetComponent<Player_Movement>().getTotalNumberOfHits();
            int totalNumberOfFalls = gameObject.GetComponent<Player_Movement>().getTotalNumberOfFalls();
            float totalTimeTaken = TimeElapsed._stopWatch.ElapsedMilliseconds + (5000.0f*totalNumberOfFalls) + (5000.0f*totalNumberOfHits);
            List<List<float>> hitLocations = gameObject.GetComponent<Player_Movement>().getHitLocations();
            string hitLocationsString = LevelAnalytics.formatHitLocations(hitLocations);
            string fallLocation = gameObject.GetComponent<Player_Movement>().getFallLocations();
            int bulletsShot = gameObject.GetComponent<ShootingScript>().getBulletsShot();
            LevelAnalytics levelAnalytics = new LevelAnalytics(getTotalNumberOfJumps(), getTotalNumberOfFreeze(), totalNumberOfHits, totalNumberOfFalls, TimeElapsed._stopWatch.ElapsedMilliseconds, true, hitLocationsString, fallLocation, bulletsShot);
            RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/4/.json",levelAnalytics);
        }
    }

    public List<Transform> getActiveCubes(){
        return activeCubes;
    }

    public void removeFromActiveCubes(Transform eatenCube){
        activeCubes.Remove(eatenCube);
    }

    public int getTotalCube(){
        return platforms.Length;
    }
}

