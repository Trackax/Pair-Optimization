using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PowerupManager powerupManager;
    //AudioManager audioManager;
    PlayerMovement playerMovement;
    [HideInInspector] public Rigidbody2D rb;
    PlayerInput playerInput;
    PlayerAttack playerAttack;
    public Transform spawn;
    public LifeManager life;

    public bool upgrade;
    public float maxUpgradeCooldown;
    private float upgradeCooldown;

    public float moveSpeed;

    [HideInInspector] public float maxFireCooldown = 1.5f;
    [HideInInspector] public float fireCooldown;
    [HideInInspector] public bool fired = false;

    public InputAction fireAction;

    [HideInInspector] public Vector2 moveInput = Vector2.zero;
    [HideInInspector] public Vector2 smoothMoveInput;
    [HideInInspector] public Vector2 moveInputSmoothVelocity;

    private void Awake()
    {
        upgradeCooldown = maxUpgradeCooldown;

        // optimization 1: searching every gameobject for a component is expensive, so i turned audio manager into a singleton to be referenced
        //audioManager = GetComponent<AudioManager>();

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

    // optimization 2: reworked function logic to avoid unnecessary comparisons

    private void Update()
    {
        HandleFire();
        HandleUpgrade();
    }

    private void HandleFire()
    {
        if (fireAction.WasPressedThisFrame() && !fired)
        {
            fired = true;
            playerAttack.FireBullet();
        }

        if (!fired) return;

        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            fired = false;
            fireCooldown = maxFireCooldown;
        }
    }

    private void HandleUpgrade()
    {
        if (!upgrade) return;

        upgradeCooldown -= Time.deltaTime;

        if (upgradeCooldown <= 0f)
        {
            upgrade = false;
            upgradeCooldown = maxUpgradeCooldown;
            maxFireCooldown = 1.5f;
            return;
        }

        maxFireCooldown = 0.75f;
    }



    //private void Update()
    //{
    //    if (fireAction.WasPressedThisFrame())
    //    {
    //        if (!fired)
    //        {
    //            fired = true;
    //            playerAttack.FireBullet();
    //        }
    //    }
    //    if (fired)
    //    {
    //        fireCooldown -= Time.deltaTime;
    //    }
    //    if (fireCooldown <= 0)
    //    {
    //        fired = false;
    //        fireCooldown = maxFireCooldown;
    //    }

    //    if (upgrade)
    //    {
    //        upgradeCooldown -= Time.deltaTime;
    //        maxFireCooldown = 0.75f;
    //    }
    //    if (upgradeCooldown <= 0)
    //    {
    //        upgrade = false;
    //        upgradeCooldown = maxUpgradeCooldown;
    //        maxFireCooldown = 1.5f;
    //    }
    //}

    private void FixedUpdate()
    {
        playerMovement.SetPlayerVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SlowEnemy"))
        {
            AudioManager.instance.PlayerDie();
            life.currentLives--;
            playerInput.enabled = false;
            this.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            powerupManager.ReturnObject(collision.gameObject);
            upgrade = true;
            AudioManager.instance.PlayerUpgrade();
        }
    }
}
