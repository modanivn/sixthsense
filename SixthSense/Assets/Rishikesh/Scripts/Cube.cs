﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float followSpeed;

    public void UpdateCubePosition(Transform followedCube, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastCubePosition(followedCube, isFollowStart));
    }

    IEnumerator StartFollowingToLastCubePosition(Transform followedCube, bool isFollowStart)
    {

        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedCube.position.x, followSpeed * Time.deltaTime),
                Mathf.Lerp(transform.position.y, followedCube.position.y, followSpeed * Time.deltaTime) - 0.01f,
                Mathf.Lerp(transform.position.z, followedCube.position.z, followSpeed * Time.deltaTime));
        }
    }
}
