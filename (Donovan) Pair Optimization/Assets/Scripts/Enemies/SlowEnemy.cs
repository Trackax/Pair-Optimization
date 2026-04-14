using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlowEnemy : MonoBehaviour
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
        Vector3 direction = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Vector3 euler = targetRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(euler.x, 90, -90);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        if (!target.activeInHierarchy)
        {
            enemyPool.ReturnObject(this.gameObject);
        }
    }
}
