using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public Transform gun;
    private int bulletCount = 0;
    
    public TextMeshProUGUI bulletText;
    private int totalShots = 0;
    private int bulletCollectedCount = 0;
 
    public void start() {
        bulletText = GetComponent<TextMeshProUGUI>();
    }
    public void Update()
    { 
        // Debug.Log("Came from stacking");
        if (hasGun && Input.GetMouseButtonDown(0) && bulletCount > 0)
        {
            Debug.Log("F Key pressed");
            // bulletsShot++;
            bulletCount --;
            totalShots++;
            bulletText.SetText((bulletCount) +" bullets left" );
            Shoot();
            
            
            
        }
        if(bulletCount == 0) {
            bulletText.enabled = false;
        }
        
        // Aim();
    }

    public int getBulletsShot() {
        return totalShots;
    }
    void Shoot()
    {
        // GameObject projectile = Instantiate(projectilePrefab, transform.GetChild(3).position, transform.GetChild(3).rotation);
        // Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // // Calculate horizontal and vertical components of the velocity
        // Vector3 aimDirection = transform.GetChild(3).right;
        // aimDirection.y = 0f;
        // Vector3 horizontalVelocity = aimDirection.normalized * projectileSpeed;
        // float verticalVelocity = ((Input.mousePosition.y / Screen.height) - 0.5f) * projectileSpeed * 2f;
        // verticalVelocity *= -1f;
        // float verticalScale = 0.25f;
        // verticalVelocity *= verticalScale;
        // // Set the velocity of the projectile
        // projectileRb.velocity = horizontalVelocity + Vector3.up * verticalVelocity;

        // GameObject projectile = Instantiate(projectilePrefab, gun.transform.GetChild(0).position, transform.GetChild(3).rotation);
        // Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // // Calculate the velocity of the projectile
        // Vector3 aimDirection = gun.transform.GetChild(0).forward;
        // Debug.Log(aimDirection);
        // float verticalVelocity = ((Input.mousePosition.y / Screen.height) - 0.5f) * projectileSpeed * 2f;
        // verticalVelocity *= -1f;
        // float verticalScale = 0.25f;
        // verticalVelocity *= verticalScale;
        // Vector3 velocity = aimDirection.normalized * projectileSpeed + Vector3.up * verticalVelocity;

        GameObject projectile = Instantiate(projectilePrefab, gun.transform.position, gun.transform.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Calculate the velocity of the projectile
        Vector3 velocity = gun.transform.forward * projectileSpeed;

        // projectileRb.velocity = velocity;

        // Set the velocity of the projectile
        projectileRb.velocity = velocity;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            
            // bulletCollectedCount+=4;
            bulletCount += 4;
            bulletText.SetText(bulletCount +  " bullets left");
            // bulletsShot = 0;
            
            Debug.Log("Bullets Collected");
            bulletText.enabled = true;
            
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


