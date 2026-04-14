using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bullet;
    private Queue<GameObject> pool = new Queue<GameObject>();
    public PlayerManager manager;
    public GameObject player;

    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return Instantiate(bullet);
    }

    public void ReturnObject(GameObject obj)
    {
        manager.fired = false;
        manager.fireCooldown = manager.maxFireCooldown;
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
