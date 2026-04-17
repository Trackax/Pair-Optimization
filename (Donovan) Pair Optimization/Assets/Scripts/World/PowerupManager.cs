using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenSpawns;
    private float timeSinceLastSpawm;
    private Queue<GameObject> pool = new Queue<GameObject>();
    public GameObject player;
    public GameObject upgrade;

    private void Update()
    {
        timeBetweenSpawns -= 0.01f * Time.deltaTime;
        if (player.activeInHierarchy && !upgrade.activeInHierarchy)
        {
            if (Time.time > timeSinceLastSpawm)
            {
                GameObject enemy = CreatePowerup();
                timeSinceLastSpawm = Time.time + timeBetweenSpawns;
            }
        }
    }

    private GameObject CreatePowerup()
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
        return Instantiate(upgrade, spawnPosition, spawnRotation);
    }

    public void ReturnObject(GameObject upgrade)
    {
        upgrade.SetActive(false);
        pool.Enqueue(upgrade);
    }
}
