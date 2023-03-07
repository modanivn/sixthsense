using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    //public Transform playerTransform;
    public GameObject player;
    public TextMeshProUGUI FreezeTimerText;
    private float repeatTime = 0.75f;
    private float startTime = 3.0f;
    private float startShootVelocity = 15.0f;
    private float shootMultipler = 12.0f;
    private float frozenCountDown = 10.0f;
    private int totalTimesProjectileFrequencyReduced = 1;
    public Image healthBarImage;
    private float currentHealth = 1.0f;
    private int numberOfLevels = 4;
    private bool hasbeenHit = false;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            numberOfLevels--;
            Debug.Log("Monster is Hit");
            Destroy(other.gameObject);
            repeatTime+=0.275f;
            CancelInvoke("shootProjectile");
            InvokeRepeating("shootProjectile", startTime, repeatTime);
            float damage = 0.25f; // set the amount of damage to be inflicted
            currentHealth -= damage;
            healthBarImage.fillAmount = currentHealth;
            if (currentHealth <= 0) {
                healthBarImage.fillAmount =  0;
                currentHealth = 0.0f;
                repeatTime = 1000.0f;
                CancelInvoke("shootProjectile");
            // Add any additional logic here for when the monster's health reaches 0
            }
            

            // Add any additional logic here for when the monster collides with a projectile
        }
    }

    public void shootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(0,0.25f,0), Quaternion.identity);

        Vector3 direction = player.transform.position - transform.position;

        Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();
        projectileRigidBody.velocity = direction.normalized * shootMultipler;
    }

    void Start()
    {
        // FreezeTimerText.text = '';
        FreezeTimerText.gameObject.SetActive(false);
        
        if(currentHealth > 0.0f){
            InvokeRepeating("shootProjectile", startTime, repeatTime);
        }

    }

   public void freezeProjectile()
   {

        FreezeTimerText.gameObject.SetActive(true);

        CancelInvoke("shootProjectile");
        frozenCountDown = 10.0f;
        FreezeTimerText.text = "Monster Frozen for " + frozenCountDown.ToString() + " seconds.";

        InvokeRepeating("UpdateCountdown", 0.0f, 1.0f);
        Invoke("unfreezeProjectile",10.0f);
   }

   void UpdateCountdown() {
        // frozenCountDown -= 1.0f;
        FreezeTimerText.text = "Monster Frozen for " + Mathf.CeilToInt(frozenCountDown).ToString() + " seconds.";
        frozenCountDown -= 1.0f;
   }

   void unfreezeProjectile()
   {
        FreezeTimerText.text = "";
        FreezeTimerText.gameObject.SetActive(false);
        CancelInvoke("UpdateCountdown");
        if(currentHealth > 0.0f){
            InvokeRepeating("shootProjectile", startTime, repeatTime);
        }
   }


}
