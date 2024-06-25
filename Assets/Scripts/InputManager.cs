using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMovement movement;
    private PlayerLook look;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        movement = GetComponent<PlayerMovement>();
        onFoot.Jump.performed += ctx => movement.Jump();

        onFoot.Sprint.started += ctx => movement.startSprint();
        onFoot.Sprint.canceled += ctx => movement.stopSprint();

        

        
        look = GetComponent<PlayerLook>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        movement.ProcessMove(onFoot.Movements.ReadValue<Vector2>()); //read the vector 2 value on the player's keyboard and translate it into character's movement using ProcessMove(vector2) over in PlayerMovement
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
