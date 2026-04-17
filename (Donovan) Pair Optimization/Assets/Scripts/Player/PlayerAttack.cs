using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    AudioManager audioManager;
    AudioSource source;
    public BulletPool bulletPool;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        source = GetComponent<AudioSource>();
    }

    public void FireBullet()
    {
        source.PlayOneShot(audioManager.fire);
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }
}
