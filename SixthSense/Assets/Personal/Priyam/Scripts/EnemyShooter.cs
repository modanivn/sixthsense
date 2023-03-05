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
    private float shootMultipler = 15.0f;
    private float frozenCountDown = 10.0f;
    private int totalTimesProjectileFrequencyReduced = 1;
    public Image healthBarImage;
    private float currentHealth = 1.0f;
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Monster is Hit");
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

   public void reduceProjectileVelocity(int numberOfLevels){

        if(numberOfLevels > totalTimesProjectileFrequencyReduced){
            float reducible = (repeatTime/numberOfLevels) * 2;
            repeatTime += reducible;
            CancelInvoke("shootProjectile");
            InvokeRepeating("shootProjectile", startTime, repeatTime);
            totalTimesProjectileFrequencyReduced += 1;
            float percentageReduce = 1/(float)numberOfLevels;
            currentHealth = currentHealth - percentageReduce;
            healthBarImage.fillAmount =  currentHealth;
        }
        else{
            healthBarImage.fillAmount =  0;
            currentHealth = 0.0f;
            repeatTime = 1000.0f;
            CancelInvoke("shootProjectile");
        }
   }
}
