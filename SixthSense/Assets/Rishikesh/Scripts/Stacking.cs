using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    private Rigidbody _playerRigidbody;
    private float _xMove;
    private float _zMove;
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;
    //
    [SerializeField] private float _speed;
    //
    List<GameObject> _cubeList = new List<GameObject>();
    private int _cubeListIndexCounter = 0;

    //Jump

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        _xMove = -Input.GetAxis("Vertical");
        _zMove = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            _playerRigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        Vector3 forwardMove = Vector3.forward * _zMove *_speed * Time.deltaTime;
        Vector3 horizontalMove = Vector3.right * _xMove * _speed * Time.deltaTime;
        _playerRigidbody.MovePosition(transform.position + forwardMove + horizontalMove);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            _cubeList.Add(other.gameObject);
            if (_cubeList.Count==1)
            {
                _firstCubePos = GetComponent<MeshRenderer>().bounds.max;
                _currentCubePos = new Vector3(other.transform.position.x, _firstCubePos.y, other.transform.position.z);
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<Cube>().UpdateCubePosition(transform, true);
            }
            else if (_cubeList.Count > 1)
            {
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<Cube>().UpdateCubePosition(_cubeList[_cubeListIndexCounter].transform, true);
                _cubeListIndexCounter++;
            }
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
