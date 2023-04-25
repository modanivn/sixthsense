using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 80f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    private int bulletsShot = 0;
    private bool canRespawn = true;
    private Vector3 respawnPosition;
    private GameObject currentGunPrefab;
    public Transform gun;
    private int bulletCount = 0;
    public GameObject crosshair;
    public TextMeshProUGUI bulletText;
    private int totalShots = 0;
    private int bulletCollectedCount = 0;
    public GameObject bulletbar;
    private int initialbullet = 0;

    

 
    public void start() {
        bulletText = GetComponent<TextMeshProUGUI>();
    }
    public void Update()
    {
        if(gun != null){
            bool isAiming = gameObject.GetComponent<Player_Movement>().isCameraAiming();

            if (isAiming){
                crosshair.SetActive(true);
            }
            else{
                crosshair.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0) && bulletCount > 0)
            {
                // Transform parentTransform = bulletbar.transform;
                // Transform childTransform = parentTransform.GetChild(bulletCount-1);
                // Image childImage = childTransform.GetComponent<Image>();
                // childImage.color = Color.white;
                bulletCount --;
                totalShots++;
                bulletText.SetText((bulletCount) +" " );
                Shoot();
                
            }
            // if(bulletCount == 0) {
            //     bulletText.enabled = false;
            // }
        }

    }

    public int getBulletsShot() {
        return totalShots;
    }
    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, gun.transform.position, gun.transform.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        Vector3 velocity = gun.transform.forward * projectileSpeed;
        projectileRb.velocity = velocity;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            // initialbullet = bulletCount;
            // Transform parentTransform = bulletbar.transform;
            bulletCount += 4;
            if (bulletCount>8){
                bulletCount = 8;
            }
            // for (int i = initialbullet; i < bulletCount; i++) {
            //     Transform childTransform = parentTransform.GetChild(i);
            //     Image childImage = childTransform.GetComponent<Image>();
            //     childImage.color = Color.green;
            // }
            bulletText.SetText(bulletCount +  " ");
            bulletText.enabled = true;
        }
    }
}


