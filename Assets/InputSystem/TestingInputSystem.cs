using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.WSA;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerInputActions _playerInputActions;
    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Jump.performed += Jump_preformed;
    }

    private void FixedUpdate()
    {
        var readValue = _playerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 1f;
        _rigidbody.AddForce(new Vector3(readValue.x, 0, readValue.y) * speed, ForceMode.Force);
    }

    private void Jump_preformed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump! " + context.phase);
            _rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
