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
    private bool hasJetpack = false;
    public GameObject flame1;
    public GameObject flame2;
    public float maxJetPackFuel = 5.0f;
    private float currentFuel;
    public Slider fuelIndicator;
    public GameObject jetPack;
    void Start()
    {
        TimeElapsed.resetStopwatch();
        TimeElapsed.startTime();
        rb = GetComponent<Rigidbody>();
        lastGroundedTime = 0f;
        jumpPressedTime = -2f;
        currentFuel = maxJetPackFuel;
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
            gameObject.GetComponent<CubeLogic>().removeFromActiveCubes(other.gameObject.transform);
            StartCoroutine(gameObject.GetComponent<CubeLogic>().respawnCube("YellowCube",other.transform.parent));
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
            Screen.lockCursor = true;
            jumpPressedTime = Time.time;
        }

        if (Mathf.Abs(lastGroundedTime - jumpPressedTime) <= jumpButtonGracePeriod && !hasJetpack)
        {
            Jump();
            jumpPressedTime = -2f;
            lastGroundedTime = 0f;
        }

        if(Input.GetAxis("Jump") > 0f && hasJetpack && currentFuel > 0.2f){
            jetPackFly();
        }
        else{
            jetPackStall();
        }

        if (transform.position.y < -5.0f){
            gameObject.GetComponent<PanelSwitcher>().reduceTime();
            setPlayerToResetPosition();
            totalNumberOfFalls++;
             jumpString += "[" + jumpX.ToString() + ", " + jumpZ.ToString() + " ], ";
        }
    }

    private void jetPackFly(){
        currentFuel -= Time.deltaTime;
        currentFuel = Mathf.Max(0.0f,currentFuel);
        rb.AddForce(rb.transform.up * 0.2f, ForceMode.Impulse);

        if(flame1 != null && flame2 != null){
            flame1.SetActive(true);
            flame2.SetActive(true);
        }
        if(fuelIndicator != null){
            fuelIndicator.value = (currentFuel/maxJetPackFuel);
        }
    }

    private void jetPackStall(){
        currentFuel += (Time.deltaTime * 0.5f);
        currentFuel = Mathf.Min(maxJetPackFuel,currentFuel);
        if(flame1 != null && flame2 != null){
            flame1.SetActive(false);
            flame2.SetActive(false);
        }
        if(fuelIndicator != null){
            fuelIndicator.value = (currentFuel/maxJetPackFuel);
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

    public void gotJetPack(){
        if(jetPack != null){
            hasJetpack = true;
            jetPack.SetActive(true);
        }
    }

    public void dropJetPack(){
        if(jetPack != null){
            hasJetpack = false;
            jetPack.SetActive(false);
        }
    }

}
