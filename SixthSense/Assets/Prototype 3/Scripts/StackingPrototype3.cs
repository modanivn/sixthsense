using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingPrototype3 : MonoBehaviour
{
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;
    private string[] orderSequence = {"YellowCube","GreenCube","YellowCube","RedCube"};

    List<GameObject> _cubeList = new List<GameObject>();
    private int _cubeListIndexCounter = 0;
    Collider m_Collider;
    public GameObject head;

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log(other);
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
    }
}
