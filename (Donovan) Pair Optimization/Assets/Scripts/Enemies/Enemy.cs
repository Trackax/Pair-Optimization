using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject target;
    EnemyPool enemyPool;

    private void Awake()
    {
        enemyPool = FindAnyObjectByType<EnemyPool>();
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        speed += 0.01f * Time.deltaTime;
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        if (!target.activeInHierarchy)
        {
            enemyPool.ReturnObject(this.gameObject);
        }
    }
}
