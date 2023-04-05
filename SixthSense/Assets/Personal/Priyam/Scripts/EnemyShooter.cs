using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject player;
    public TextMeshProUGUI FreezeTimerText;
    private float repeatTime = 1.5f;
    private float startTime = 3.0f;
    private float startShootVelocity = 15.0f;
    private float shootMultipler = 12.0f;
    private float frozenCountDown = 10.0f;
    public Image healthBarImage;
    public float currentHealth = 1.0f;
    public GameObject gameEndTrigger;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            decreaseMonsterHealth();
            
        }
        if (other.gameObject.CompareTag("YellowCube")) {
            increaseMonsterHealth();
            player.GetComponent<CubeLogic>().removeFromActiveCubes(other.gameObject.transform);
            StartCoroutine(player.GetComponent<CubeLogic>().respawnCube(other.tag,other.transform.parent));
            Destroy(other.gameObject);
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

      public void decreaseMonsterHealth(){
        float healthDecreses = 0.2f;
        currentHealth -= healthDecreses;
        currentHealth = (float)System.Math.Round(Mathf.Max(0.0f,currentHealth),1);
        healthBarImage.fillAmount = currentHealth;
        if(currentHealth > 0.0f){
            repeatTime = Mathf.Abs(1.5f + (1.0f-currentHealth));
            CancelInvoke("shootProjectile");
            InvokeRepeating("shootProjectile", startTime, repeatTime);
        }
        else{
            gameEndTrigger.SetActive(true);
            gameObject.transform.position = new Vector3(1000.0f, 1000.0f, 1000.0f);
            Object.Destroy(gameObject, 10.0f);
            CancelInvoke("shootProjectile");
        }
        return;
   }

   public void increaseMonsterHealth(){
        float healthIncrease = 0.1f;
        currentHealth += healthIncrease;
        currentHealth = Mathf.Min(1.0f,currentHealth);
        healthBarImage.fillAmount = currentHealth;
        repeatTime = Mathf.Abs(1.5f + (1.0f-currentHealth));
        CancelInvoke("shootProjectile");
        InvokeRepeating("shootProjectile", startTime, repeatTime);
   }
}
