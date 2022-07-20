using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float horizontalRotationSpeed;
    [SerializeField] float verticalRotationSpeed;
    [SerializeField] float verticalRestriction;
    [SerializeField] float jumpHeight;
    [SerializeField] KeyCode sprintKey;

    private float _localX;
    private Vector3 _direction;
    private float _gravity;
    private Vector3 _yVelocity;
    private float _horizontalInput;
    private float _verticalInput;
    
    private CharacterController _moveController;
    private Transform _playerCamera;
    private InventoryManager _playerInventory;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _moveController = gameObject.GetComponent<CharacterController>();
        _playerInventory = gameObject.GetComponent<InventoryManager>();
        
        _playerCamera = transform.Find("Main Camera");
        _gravity = -9.81f;
        _yVelocity= new Vector3(0, _gravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Mouse X");
        _verticalInput = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * (_horizontalInput * horizontalRotationSpeed * Time.deltaTime));
        _playerCamera.Rotate(Vector3.left * (_verticalInput * verticalRotationSpeed * Time.deltaTime));
        
        LimitX();
    }

    private void FixedUpdate()
    {
        _direction = Vector3.Normalize(transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal"));

        _yVelocity = SetYVelocity();
        float moveSpeed = speed;
        if (Input.GetKey(sprintKey)) { moveSpeed = speed * 2; }
        _moveController.Move((_yVelocity + _direction * moveSpeed) * Time.deltaTime );
    }

    private Vector3 SetYVelocity()
    {
        if (!_moveController.isGrounded) 
            return new Vector3(_yVelocity.x,_yVelocity.y+_gravity*Time.deltaTime,_yVelocity.z);
        if (Input.GetKey(KeyCode.Space)) 
            return new Vector3(0,Mathf.Sqrt(jumpHeight * -2f * _gravity),0);
        return Vector3.zero;
    }

    private void LimitX()
    {
        _localX = _playerCamera.localEulerAngles.x;
        if (_localX > 180) _localX -= 360;
        if (Mathf.Abs(_localX) > verticalRestriction)
            _playerCamera.localEulerAngles = new Vector3(Mathf.Clamp(_localX,-verticalRestriction,verticalRestriction), 0, 0);
    }
}
