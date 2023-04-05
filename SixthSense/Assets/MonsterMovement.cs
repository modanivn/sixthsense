using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private List<Transform> targetObjects;
    public float speed = 0.001f;
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
    }

    void Update()
    {
        targetObjects = player.GetComponent<CubeLogic>().getActiveCubes();
        Transform closestObject = GetClosestTargetObject();
        if (closestObject != null && gameObject.GetComponent<EnemyShooter>().currentHealth >= 0f)
        {
            startPoint = transform;
            endPoint = closestObject.transform;
            journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, 0.00115f);
        }
    }

    private Transform GetClosestTargetObject()
    {
        Transform closestObject = null;
        float closestDistance = Mathf.Infinity;
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
        return closestObject;
    }   

}
