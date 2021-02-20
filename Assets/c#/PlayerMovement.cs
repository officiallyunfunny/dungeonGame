using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Rigidbody2D _playerRb;

    private InputMaster _controls;
    
    private void Start()
    {
        _controls = new InputMaster();
        _controls.Enable();
        
    }

    [Client]
    private void FixedUpdate()
    {
        if(!isLocalPlayer) return;
        
        
        CmdMovePlayer(_controls.Player.movement.ReadValue<Vector2>());
    }

    [Command]
    private void CmdMovePlayer(Vector2 direction)
    {
        _playerRb.MovePosition(_playerRb.position + direction * _playerSpeed * Time.fixedDeltaTime);
    }
    
}
