using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -20f, 20f);
        pos.y = Mathf.Clamp(pos.y, -9.5f, 11.15f);
        transform.position = pos;
    }

    private void OnMove(InputValue inputValue)
    {
        playerManager.moveInput = inputValue.Get<Vector2>();
    }

    public void SetPlayerVelocity()
    {
        playerManager.smoothMoveInput = Vector2.SmoothDamp(playerManager.smoothMoveInput, playerManager.moveInput, ref playerManager.moveInputSmoothVelocity, 0.1f);
        playerManager.rb.velocity = playerManager.smoothMoveInput * playerManager.moveSpeed;
    }
}
