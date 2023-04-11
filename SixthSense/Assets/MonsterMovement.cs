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
    public float monsterSpeed = 4.0f;

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
        if (closestObject != null && gameObject.GetComponent<EnemyShooter>().currentHealth > 0f)
        {
            startPoint = transform;
            endPoint = closestObject.transform;
            Vector3 direction = (endPoint.position - startPoint.position).normalized;
            transform.position = transform.position + (direction * (monsterSpeed * Time.deltaTime));
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rotation;
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
            if(targetObject != null){
                float distance = Vector3.Distance(transform.position, targetObject.position);
                if (distance < closestDistance)
                {
                    closestObject = targetObject;
                    closestDistance = distance;
                }
            }
        }
        return closestObject;
    }   

}
