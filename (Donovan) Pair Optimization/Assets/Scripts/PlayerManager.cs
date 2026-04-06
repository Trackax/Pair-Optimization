using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    [HideInInspector] public Rigidbody rb;
    PlayerInput playerInput;
    PlayerAttack playerAttack;

    public GameObject bullet;
    public Transform bulletStart;

    public float moveSpeed;

    public InputAction fireAction;

    [HideInInspector] public Vector2 moveInput = Vector2.zero;
    [HideInInspector] public Vector2 smoothMoveInput;
    [HideInInspector] public Vector2 moveInputSmoothVelocity;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerAttack = GetComponent<PlayerAttack>();
        fireAction = playerInput.actions.FindAction("Fire");
    }

    private void Update()
    {
        if (fireAction.WasPressedThisFrame())
        {
            playerAttack.FireBullet();
        }
    }

    private void FixedUpdate()
    {
        playerMovement.SetPlayerVelocity();
    }
}
