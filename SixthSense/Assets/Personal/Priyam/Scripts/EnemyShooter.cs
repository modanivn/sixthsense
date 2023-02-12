using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    //public Transform playerTransform;
    public GameObject player;
    public void shootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Vector3 direction = player.transform.position - transform.position;

        Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();
        projectileRigidBody.velocity = direction.normalized * 10;
    }
    void Start()
    {
        InvokeRepeating("shootProjectile", 2.0f, 1.75f);

    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
