using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private List<Transform> targetObjects;
    public float speed = 1f;
    private Transform startPoint;
    private Transform endPoint;
    private float startTime;
    private float journeyLength;
    public GameObject player;

    void Start()
    {
        startTime = Time.time;
        targetObjects = player.GetComponent<CubeLogic>().getActiveCubes();
        
        startPoint = transform;
        endPoint = GetClosestTargetObject().transform;
        // journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        // Debug.Log(targetObjects.Count);
        Debug.Log(startPoint.position);
    }

    void Update()
    {
        targetObjects = player.GetComponent<CubeLogic>().getActiveCubes();
        Transform closestObject = GetClosestTargetObject();
        if (closestObject != null)
        {
            startPoint = transform;
            endPoint = closestObject.transform;
            Debug.Log(startPoint.position);
            journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, 0.001f);
        }
    }

    // void FixedUpdate()
    // {
    //     float distCovered = (Time.time - startTime) * speed;
    //     float fracJourney = distCovered / journeyLength;
    //     transform.position = Vector3.Lerp(startPoint.position, endPoint.position, 0.01f);
    // }

    private Transform GetClosestTargetObject()
    {
        Transform closestObject = null;
        float closestDistance = Mathf.Infinity;
        
        Debug.Log("Count: " + targetObjects.Count);
        if(targetObjects.Count == 0) {
            return null;
        }
        foreach (Transform targetObject in targetObjects)
        {
            float distance = Vector3.Distance(transform.position, targetObject.position);
            if (distance < closestDistance)
            {
                closestObject = targetObject;
                closestDistance = distance;
            }
        }
        Debug.Log(closestObject.position);
        return closestObject;
    }   

}
