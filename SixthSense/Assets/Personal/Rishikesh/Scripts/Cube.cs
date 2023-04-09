using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    [SerializeField] float speed = 150f;
    

    private Material originalMaterial;
    private Material currentMaterial;
    private bool isChangingMaterial = false;
    public Material redMaterial;
    private string originalTag;


    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
        currentMaterial = originalMaterial;
        originalTag = gameObject.tag;
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet") && !isChangingMaterial)
        {
            StartCoroutine(ChangeMaterialForSeconds(redMaterial, 10f));
        }
    }

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
                followedCube.position.y + 0.1f,
                Mathf.Lerp(transform.position.z, followedCube.position.z, followSpeed * Time.deltaTime));
        }
    }

    IEnumerator ChangeMaterialForSeconds(Material newMaterial, float duration)
    {
        isChangingMaterial = true;
        currentMaterial = newMaterial;
        GetComponent<Renderer>().material = currentMaterial;
        gameObject.tag = "dangerCube";
        yield return new WaitForSeconds(duration);
        currentMaterial = originalMaterial;
        GetComponent<Renderer>().material = currentMaterial;
        gameObject.tag = originalTag;
        isChangingMaterial = false;
    }

    public void update() {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
