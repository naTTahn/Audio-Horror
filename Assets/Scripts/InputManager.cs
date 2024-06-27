using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    public PlayerInput.OnFootActions OnFoot;
    private PlayerMovement _movement;
    private PlayerLook _look;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        _playerInput = new PlayerInput();
        OnFoot = _playerInput.OnFoot;
        _movement = GetComponent<PlayerMovement>();
        OnFoot.Jump.performed += ctx => _movement.Jump();

        OnFoot.Sprint.started += ctx => _movement.StartSprint();
        OnFoot.Sprint.canceled += ctx => _movement.StopSprint();

        

        
        _look = GetComponent<PlayerLook>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _movement.ProcessMove(OnFoot.Movements.ReadValue<Vector2>()); //read the vector 2 value on the player's keyboard and translate it into character's movement using ProcessMove(vector2) over in PlayerMovement
    }
    private void LateUpdate()
    {
        _look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());

    }
    private void OnEnable()
    {
        OnFoot.Enable();
    }
    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
