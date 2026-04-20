using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    ScoreManager scoreManager;
    BulletPool bulletPool;
    EnemyPool enemyPool;
    public float speed;
    GameObject player;
    public float height;

    private void Awake()
    {
        enemyPool = FindAnyObjectByType<EnemyPool>();
        bulletPool = FindAnyObjectByType<BulletPool>();
        scoreManager = FindAnyObjectByType<ScoreManager>();     
        player = GameObject.FindWithTag("Player");
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }

    void Update()
    {
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            bulletPool.ReturnObject(this.gameObject);
        }
        if (collision.gameObject.CompareTag("SlowEnemy"))
        {
            AudioManager.instance.EnemyDie();
            scoreManager.AddPoint();
            enemyPool.ReturnObject(collision.gameObject);
            bulletPool.ReturnObject(this.gameObject);
        }
    }
}
