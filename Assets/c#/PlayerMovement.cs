using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Rigidbody2D _playerRb;
    private Vector2 _direction;

    private InputMaster _controls;
    
    [Client]
    private void Start()
    {
        if(!isLocalPlayer || !hasAuthority) return;
        
        _controls = new InputMaster();
        _controls.Enable();
        
    }

    [Client]
    private void Update()
    {
        if(!isLocalPlayer || !hasAuthority) return;
        _direction = _controls.Player.movement.ReadValue<Vector2>();
    }

    [Client]
    private void FixedUpdate()
    {
        if(!isLocalPlayer || !hasAuthority) return;

        
        _playerRb.MovePosition(_playerRb.position + _direction * _playerSpeed * Time.fixedDeltaTime);

    }

    
}
