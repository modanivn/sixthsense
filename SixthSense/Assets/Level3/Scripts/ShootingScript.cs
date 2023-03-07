using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    private int bulletsShot = 0;
    private bool canRespawn = true;
    private Vector3 respawnPosition;
    private GameObject currentGunPrefab;
    private bool hasGun = false;
    

    public void Update()
    { 
        // Debug.Log("Came from stacking");
        if (hasGun && Input.GetKeyDown(KeyCode.F) && bulletsShot<4)
        {
            Debug.Log("F Key pressed");
            bulletsShot++;
            Shoot();
            
            
            
        }
        
        // Aim();
    }


    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.GetChild(3).position, transform.GetChild(3).rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Calculate horizontal and vertical components of the velocity
        Vector3 aimDirection = transform.GetChild(3).right;
        aimDirection.y = 0f;
        Vector3 horizontalVelocity = aimDirection.normalized * projectileSpeed;
        float verticalVelocity = ((Input.mousePosition.y / Screen.height) - 0.5f) * projectileSpeed * 2f;
        verticalVelocity *= -1f;
        float verticalScale = 0.25f;
        verticalVelocity *= verticalScale;
        // Set the velocity of the projectile
        projectileRb.velocity = horizontalVelocity + Vector3.up * verticalVelocity;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            bulletsShot = 0;
            hasGun = true;
            
        }
    }




// void Shoot()
// {
//     GameObject projectile = Instantiate(projectilePrefab, transform.GetChild(3).position, transform.GetChild(3).rotation);
//     Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

//     // Calculate horizontal and vertical components of the velocity
//     Vector3 aimDirection = transform.GetChild(3).forward;
//     aimDirection.y = 0f;
//     Vector3 horizontalVelocity = aimDirection.normalized * projectileSpeed;
//     float verticalVelocity = ((Input.mousePosition.y) / Screen.height) * projectileSpeed * 2f - projectileSpeed;

//     // Set the velocity of the projectile
//     float verticalScale = 0.1f;
//     verticalVelocity *= verticalScale;
//     projectileRb.velocity = horizontalVelocity + Vector3.up * verticalVelocity;
// }

    // void Shoot()
    // {
    //     GameObject projectile = Instantiate(projectilePrefab, transform.GetChild(3).position, transform.GetChild(3).rotation);
    //     Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
    //     projectileRb.velocity = transform.GetChild(3).forward * projectileSpeed;
    // }

//     void Aim()
// {
//     // Get the position of the mouse cursor in the world space
//     Vector3 mousePos = Input.mousePosition;
//     mousePos.z = 10f; // Distance from the camera to the cursor
//     Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);

//     // Rotate the weapon towards the target position
//     Vector3 aimDirection = targetPos - transform.GetChild(3).position;
//     aimDirection.y = 0f; // Lock aim direction to horizontal plane
//     if (aimDirection.magnitude > 0f) // Avoid errors when target is directly below the weapon
//     {
//         Quaternion targetRotation = Quaternion.LookRotation(aimDirection);
//         transform.GetChild(3).rotation = targetRotation;
//     }
// }
}


