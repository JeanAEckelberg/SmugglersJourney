using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float horizontalRotationSpeed;
    [SerializeField] float verticalRotationSpeed;
    [SerializeField] float verticalRestriction;
    
    private float _localX;
    private float _horizontalInput;
    private float _verticalInput;
    private CharacterController _moveController;
    private Transform _playerCamera;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _moveController = gameObject.GetComponent<CharacterController>();
        _playerCamera = transform.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Mouse X");
        _verticalInput = Input.GetAxis("Mouse Y");
        
        if (Input.GetKey(KeyCode.W))
        {
            _moveController.Move(transform.forward * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveController.Move(transform.right * (-speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveController.Move(transform.forward * (-speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveController.Move(transform.right * (speed * Time.deltaTime));
        }
        
        transform.Rotate(Vector3.up * (_horizontalInput * horizontalRotationSpeed * Time.deltaTime));
        _playerCamera.Rotate(Vector3.left * (_verticalInput * verticalRotationSpeed * Time.deltaTime));
        
        _localX = _playerCamera.localEulerAngles.x;
        if (_localX > 180) _localX -= 360;
        _playerCamera.localEulerAngles = new Vector3(Mathf.Clamp(_localX,-verticalRestriction,verticalRestriction), 0, 0);
    }
}
