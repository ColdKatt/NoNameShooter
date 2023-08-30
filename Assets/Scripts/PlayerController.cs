using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Transform _pistol;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Weapon _weapon;
    private float _movementX;
    private float _movementY;
    private Vector3 _cursorPos;
    private bool _isGrounded;
    private bool _isJumping;

    void Awake()
    {
        _input = new PlayerInput();
        _input.PlayerKeyboard.Enable();
        _weapon.Init();
        Debug.Log(_weapon.WeaponStHandler.State);
        //_weapon.SetState(new ShootState());
    }

    private void OnEnable()
    {
        _input.PlayerKeyboard.Jump.started += DoJump;
        _input.PlayerKeyboard.Jump.canceled += DoJump;
        _input.PlayerKeyboard.Shoot.started += Shoot;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void DoJump(InputAction.CallbackContext context)
    {
        _isJumping = context.phase == InputActionPhase.Started ? true : (context.phase == InputActionPhase.Canceled ? false : _isJumping);
    }

    private void OnDisable()
    {
        _input.PlayerKeyboard.Jump.started -= DoJump;
        _input.PlayerKeyboard.Jump.canceled -= DoJump;
        _input.PlayerKeyboard.Shoot.started -= Shoot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name);
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (_weapon.WeaponStHandler.State is not ShootState) return;

        _weapon.WeaponStHandler.ChangeState();
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.Euler(0, 0, 0));
        bullet.GetComponent<Bullet>().PistolTransform = _pistol;
        
        _weapon.OnStateChanged?.Invoke();
    }

    void FixedUpdate()
    {
        if (_isJumping && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
        Vector3 movement = new Vector3(_movementX, _movementY, 0.0f);
        transform.Translate(movement * _speed * Time.deltaTime);

        //Aim
        Vector2 movementVector = Mouse.current.position.ReadValue();
        _cursorPos = Camera.main.ScreenToWorldPoint(movementVector);
        _cursorPos.z = 0f;

        Vector3 lookDir = _pistol.position - _cursorPos;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        _pistol.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180));
    }
}
