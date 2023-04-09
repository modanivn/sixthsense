using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    public Vector2 turn;
    public Vector3 deltaMove;
    public float sensitivity = 4.0f;
    private bool isAiming = false;
    public CinemachineVirtualCamera aimCamera;
    public int totalNumberOfHits;
    public int totalNumberOfFalls;
    public List<List<float>> hitLocations = new List<List<float>>();
    public float jumpButtonGracePeriod;
    private float lastGroundedTime;
    private float jumpPressedTime;
    private float jumpX;
    private float jumpZ;
    private string jumpString = "";
    public GameObject gun;
    public float respawnX = -14.0f;
    public float respawnY = 2.5f;
    public float respawnZ = 0f;
    void Start()
    {
        TimeElapsed.resetStopwatch();
        TimeElapsed.startTime();
        rb = GetComponent<Rigidbody>();
        lastGroundedTime = 0f;
        jumpPressedTime = -2f;
        Screen.lockCursor = true;

    }
     public string getFallLocations() {
        return jumpString;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            hitLocations.Add(new List<float>() { gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z });
            gameObject.GetComponent<PanelSwitcher>().reduceTime();
            Destroy(other.gameObject);
            totalNumberOfHits++;
        }
        if(other.gameObject.tag == "dangerCube")
        {
            gameObject.GetComponent<PanelSwitcher>().reduceTime();
            Destroy(other.gameObject);
        }

    }

    public int getTotalNumberOfHits() {
        return totalNumberOfHits;
    }

    public int getTotalNumberOfFalls() {
        return totalNumberOfFalls;
    }

    public List<List<float>> getHitLocations() {
        return hitLocations;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = -Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        sensitivity = PlayerPrefs.GetFloat("sensitivity");
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(0,turn.x,0);
        deltaMove = new Vector3(horizontalInput,0,-verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(deltaMove);

        if (Input.GetMouseButtonDown(1))
        {
            isAiming = !isAiming;
        }

        if(aimCamera != null){
            if (isAiming)
            {
                aimCamera.Priority = 20;
                aimCamera.enabled = true;
                turn.y -= Input.GetAxis("Mouse Y") * sensitivity;
                turn.y = Mathf.Clamp(turn.y, -20f, 20f);
                gun.transform.localRotation = Quaternion.Euler(turn.y, 180, 0);
            }
            else
            {
                aimCamera.Priority = 1;
                aimCamera.enabled = false;
                gun.transform.localRotation = Quaternion.Euler(0, 180, 0);
                turn.y = 0;
            }
        }


        

        if(IsGrounded())
        {
            jumpX = transform.position.x;
            jumpZ = transform.position.z;
            lastGroundedTime = Time.time;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressedTime = Time.time;
        }

        if (Mathf.Abs(lastGroundedTime - jumpPressedTime) <= jumpButtonGracePeriod)
        {
            Jump();
            jumpPressedTime = -2f;
            lastGroundedTime = 0f;
        }

        if (transform.position.y < -5.0f){
            gameObject.GetComponent<PanelSwitcher>().reduceTime();
            setPlayerToResetPosition();
            totalNumberOfFalls++;
             jumpString += "[" + jumpX.ToString() + ", " + jumpZ.ToString() + " ], ";
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    public void addForce(float multiplier){
        jumpForce = jumpForce + multiplier;
    }

    public void decreaseForce(float multiplier){
        jumpForce = jumpForce - multiplier;
        jumpForce = Mathf.Max(4f,jumpForce);
    }

    public void setPlayerToResetPosition(){
        gameObject.transform.position = new Vector3(respawnX, respawnY, respawnZ);
    }

    public void changeCameraToDefault(){
        isAiming = false;
    }

    public bool isCameraAiming(){
        return isAiming;
    }

}
