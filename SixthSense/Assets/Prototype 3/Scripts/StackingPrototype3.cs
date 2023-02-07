using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Proyecto26;

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

    private void OnTriggerEnter(Collider other)
    {
            
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
            gameObject.GetComponent<NatkhatCubes>().funWithCube(other.gameObject);
            cubeElement.text = (8-_cubeList.Count).ToString() + " cubes remaining";

            if (_cubeList.Count == 8){
                TimeElapsed.endTime();
                Level level = new Level(true, TimeElapsed._stopWatch.ElapsedMilliseconds, _cubeList.Count);
                RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/0/.json", level);
                UnityEditor.EditorApplication.isPlaying = false;
                // Application.Quit();
            }
    }
}
