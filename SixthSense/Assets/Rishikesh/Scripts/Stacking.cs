using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class Stacking : MonoBehaviour
{
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;
    private string[] orderSequence = {"YellowCube","GreenCube","YellowCube","RedCube"};

    List<GameObject> _cubeList = new List<GameObject>();
    private int _cubeListIndexCounter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(orderSequence[_cubeList.Count]))
        {
            _cubeList.Add(other.gameObject);
            if (_cubeList.Count==1)
            {
                _firstCubePos = GetComponent<MeshRenderer>().bounds.max;
                _currentCubePos = new Vector3(other.transform.position.x, _firstCubePos.y, other.transform.position.z);
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<Cube>().UpdateCubePosition(transform, true);
            }
            else if (_cubeList.Count > 1)
            {
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<Cube>().UpdateCubePosition(_cubeList[_cubeListIndexCounter].transform, true);
                _cubeListIndexCounter++;
            }
        }
        else if(other.CompareTag("RedCube"))
        {
            TimeElapsed.endTime();
            Level level = new Level(false, TimeElapsed._stopWatch.ElapsedMilliseconds);
            RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/0/.json", level);
            // Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
            
        }

        if(_cubeList.Count == 3){
            TimeElapsed.endTime();
            Level level = new Level(true,TimeElapsed._stopWatch.ElapsedMilliseconds);
            RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/0/.json", level);
            UnityEditor.EditorApplication.isPlaying = false;
            // Application.Quit();
        }

    }
}
