using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    [HideInInspector] public Rigidbody2D rb;
    PlayerInput playerInput;
    PlayerAttack playerAttack;
    public Transform spawn;
    public LifeManager life;

    public float moveSpeed;

    public float maxFireCooldown;
    [HideInInspector] public float fireCooldown;
    [HideInInspector] public bool fired = false;

    public InputAction fireAction;

    [HideInInspector] public Vector2 moveInput = Vector2.zero;
    [HideInInspector] public Vector2 smoothMoveInput;
    [HideInInspector] public Vector2 moveInputSmoothVelocity;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerAttack = GetComponent<PlayerAttack>();
        fireAction = playerInput.actions.FindAction("Fire");
        fireCooldown = maxFireCooldown;
    }

    private void OnEnable()
    {
        transform.position = spawn.position;
    }

    private void Update()
    {
        if (fireAction.WasPressedThisFrame())
        {
            if (!fired)
            {
                fired = true;
                playerAttack.FireBullet();
            }
        }
        if (fired)
        {
            fireCooldown -= Time.deltaTime;
        }
        if (fireCooldown <= 0)
        {
            fired = false;
            fireCooldown = maxFireCooldown;
        }
    }

    private void FixedUpdate()
    {
        playerMovement.SetPlayerVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SlowEnemy"))
        {
            life.currentLives--;
            playerInput.enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
