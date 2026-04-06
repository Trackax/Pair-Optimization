using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    [HideInInspector] public Rigidbody rb;
    PlayerInput playerInput;

    public float moveSpeed;

    [HideInInspector] public Vector2 moveInput = Vector2.zero;
    [HideInInspector] public Vector2 smoothMoveInput;
    [HideInInspector] public Vector2 moveInputSmoothVelocity;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerMovement.SetPlayerVelocity();
    }
}
