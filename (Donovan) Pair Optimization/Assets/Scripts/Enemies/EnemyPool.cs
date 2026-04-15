using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenSpawns;
    private float timeSinceLastSpawm;

    private Queue<GameObject> pool = new Queue<GameObject>();
    public GameObject slowEnemy;
    public GameObject player;

    private void Update()
    {
        timeBetweenSpawns -= 0.01f * Time.deltaTime;
        if (player.activeInHierarchy)
        {
            if (Time.time > timeSinceLastSpawm)
            {
                GameObject enemy = CreateEnemy();
                timeSinceLastSpawm = Time.time + timeBetweenSpawns;
            }
        }
        if (!player.activeInHierarchy)
        {
            timeBetweenSpawns = 1;
        }
    }

    private GameObject CreateEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;
        Quaternion spawnRotation = spawnPoints[randomIndex].transform.rotation;

        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            obj.transform.position = spawnPosition;
            return obj;
        }
        return Instantiate(slowEnemy, spawnPosition, spawnRotation);
    }

    public void ReturnObject(GameObject enemy)
    {
        enemy.SetActive(false);
        pool.Enqueue(enemy);
    }
}
