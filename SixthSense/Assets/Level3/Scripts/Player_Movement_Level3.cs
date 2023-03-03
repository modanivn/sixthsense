using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.SceneManagement;

public class Player_Movement_Level3 : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    public Vector2 turn;
    public Vector3 deltaMove;
    public float sensitivity = 4.0f;

    public int totalNumberOfHits;
    public int totalNumberOfFalls;
    public List<List<float>> hitLocations = new List<List<float>>();
    
    //public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        TimeElapsed.startTime();
        rb = GetComponent<Rigidbody>();
        transform.localRotation = Quaternion.Euler(0,90,0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            hitLocations.Add(new List<float>() { gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z });
            // TimeElapsed.subtractTime();
            gameObject.GetComponent<PanelSwitcher_Level3>().reduceTime();
            gameObject.GetComponent<StackingPrototype3_Level3>().emptyPlayerStack();
            Destroy(other.gameObject);
            totalNumberOfHits++;

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

        // rb.velocity = new Vector3(verticalInput * movementSpeed, rb.velocity.y, horizontalInput * movementSpeed);

        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(0,turn.x,0);
        deltaMove = new Vector3(horizontalInput,0,-verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(deltaMove);


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }


        if (transform.position.y < -5.0f){
            
            // TimeElapsed.endTime();
            // Level level = new Level(false, TimeElapsed._stopWatch.ElapsedMilliseconds, gameObject.GetComponent<StackingPrototype3>()._cubeList.Count);
            // RestClient.Post("https://unityanalytics-d1032-default-rtdb.firebaseio.com/0/.json", level);
            // gameObject.GetComponent<StackingPrototype3>().emptyPlayerStack();

            // UnityEditor.EditorApplication.isPlaying = false;
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // TimeElapsed.subtractTime();

            gameObject.GetComponent<PanelSwitcher_Level3>().reduceTime();
            gameObject.GetComponent<StackingPrototype3_Level3>().emptyPlayerStack();
            setPlayerToResetPosition();
            totalNumberOfFalls++;
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

    void Rotation(){
        // transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X")*4f,0));
    }

    public void addForce(float multiplier){
        jumpForce = jumpForce + multiplier;
    }

    public void decreaseForce(float multiplier){
        jumpForce = jumpForce - multiplier;
        jumpForce = Mathf.Max(4f,jumpForce);
    }

    public void setPlayerToResetPosition(){
        gameObject.transform.position = new Vector3(-14, 2.5f, 0);
    }

}
