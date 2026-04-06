using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(playerManager.bullet, playerManager.bulletStart.position, transform.rotation);
    }
}
