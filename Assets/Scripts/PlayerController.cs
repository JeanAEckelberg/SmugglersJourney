using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float horizontalRotationSpeed;
    [SerializeField] float verticalRotationSpeed;
    [SerializeField] float verticalRestriction;
    [SerializeField] float jumpHeight;
    
    private float _localX;
    private Vector3 _direction;
    private float _gravity;
    private Vector3 _yVelocity;
    private float _horizontalInput;
    private float _verticalInput;
    private CharacterController _moveController;
    private Transform _playerCamera;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _moveController = gameObject.GetComponent<CharacterController>();
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
        
        _localX = _playerCamera.localEulerAngles.x;
        if (_localX > 180) _localX -= 360;
        if (Mathf.Abs(_localX) > verticalRestriction)
            _playerCamera.localEulerAngles = new Vector3(Mathf.Clamp(_localX,-verticalRestriction,verticalRestriction), 0, 0);
    }

    private void FixedUpdate()
    {
        _direction = Vector3.Normalize(transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal"));

        _yVelocity.y += _gravity * Time.deltaTime;
        
        if (_moveController.isGrounded) _yVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.Space) && _moveController.isGrounded)
        {
            _yVelocity = new Vector3(0,Mathf.Sqrt(jumpHeight * -2f * _gravity),0);
        }
        
        _moveController.Move((_yVelocity + _direction * speed) * Time.deltaTime );
    }
}
