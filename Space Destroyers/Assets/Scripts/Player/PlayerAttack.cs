using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    AudioSource source;
    public BulletPool bulletPool;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void FireBullet()
    {
        source.PlayOneShot(AudioManager.instance.fire);
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }
}
