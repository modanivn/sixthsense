using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    
    // [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        TimeElapsed.startTime();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            TimeElapsed.endTime();
            Level level = new Level(false, TimeElapsed._stopWatch.ElapsedMilliseconds);
            RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/0/.json", level);
            // Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
        float horizontalInput = -Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        // jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.CompareTag("Enemy Head"))
        // {
        //     Destroy(collision.transform.parent.gameObject);
        //     Jump();
        // }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
