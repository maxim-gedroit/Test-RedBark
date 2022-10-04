using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    [SerializeField] private float _viewClampYMin = -70f;
    [SerializeField] private float _viewClampYMax = 80f;
    [SerializeField] private float _viewSensitivity = 400f;
    
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private Vector3 _cameraRotation;
    private Vector3 _playerRotation;
    private Vector2 InputView;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.View.performed += e => InputView = e.ReadValue<Vector2>();
        _playerInput.Player.Fire.performed += FireOnperformed;
        _playerInput.Enable();
        
        InitView();
    }
    
    private void InitView()
    {
        _characterController = GetComponent<CharacterController>();
        _playerRotation = transform.localRotation.eulerAngles;
        _cameraRotation = _camera.transform.localRotation.eulerAngles;
    }

    private void FireOnperformed(InputAction.CallbackContext obj)
    {
    }

    private void Update()
    {
        CalculateView();
    }

    private void CalculateView()
    {
        _playerRotation.y += InputView.x * _viewSensitivity * Time.deltaTime;
        transform.localRotation  = Quaternion.Euler (_playerRotation);
        
        _cameraRotation.x += _viewSensitivity * -InputView.y * Time.deltaTime;
        _cameraRotation.x = Mathf.Clamp(_cameraRotation.x, _viewClampYMin, _viewClampYMax);
        _camera.transform.localRotation = Quaternion.Euler(_cameraRotation);
    }
}
