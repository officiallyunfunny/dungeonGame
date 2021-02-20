using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    public float speed = 5;
    public InputMaster controls;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Camera _playerCamera;

    [Client]
    private void Start()
    {
        if (!isLocalPlayer) return;
        Camera.main.enabled = false;
        _playerCamera.enabled = true;
        controls = new InputMaster();
        controls.Enable();
        
        
    }
    
    [Client]
    void Update()
    {
        if (!isLocalPlayer) return;

        Vector2 movementInput = controls.Player.movement.ReadValue<Vector2>();
        transform.position += (Vector3)movementInput.normalized * (Time.deltaTime * speed);

        if (movementInput.x != 0 || movementInput.y != 0 )
        {
            _playerAnimator.SetBool("moving", true);
            if (movementInput.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (movementInput.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            _playerAnimator.SetBool("moving", false);
        }
        
        
        
    }


    
}
