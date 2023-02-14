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
    private float repeatTime = 1.25f;
    private float startTime = 1.0f;
    private float frozenCountDown = 10.0f;

    public void shootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);

        Vector3 direction = player.transform.position - transform.position;

        Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();
        projectileRigidBody.velocity = direction.normalized * 15;
    }

    void Start()
    {
        // FreezeTimerText.text = '';
        FreezeTimerText.gameObject.SetActive(false);
        InvokeRepeating("shootProjectile", startTime, repeatTime);

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
        InvokeRepeating("shootProjectile", startTime, repeatTime);
   }
    // Update is called once per frame
    void Update()
    {
        
    }
}
