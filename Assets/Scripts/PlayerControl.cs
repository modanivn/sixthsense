using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed=20.0f;
    private float hspeed = 10.0f;
    private float verticalInput;
    private float horizontalInput;
    private float xRange = 8;
    public Transform parentPickup;
    public Transform stackPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.forward);
        transform.Translate(horizontalInput * hspeed * Time.deltaTime * Vector3.right);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.parent);
        if(other.tag == "Pickup")
        {
            Transform otherTransform = other.transform.parent;
            // Debug.Log("Hello");
            // Debug.Log(otherTransform);
            // GameControllerStackColor.instance.UpdateScore(otherTransform.GetComponent<PickupStack>().value);
            Rigidbody otherRB = otherTransform.GetComponent<Rigidbody>();
            otherRB.isKinematic = true;
            other.enabled = false;
            if(parentPickup == null)
            {
                parentPickup = otherTransform;
                parentPickup.position = stackPosition.position;
                parentPickup.parent = stackPosition;
            }
            else
            {
                parentPickup.position += Vector3.up * (otherTransform.localScale.y);
                // parentPickup.position +=Vector3.right * (otherTransform.localScale.x);
                otherTransform.position = stackPosition.position;
                otherTransform.parent = parentPickup;
            }
        }
    }
}
