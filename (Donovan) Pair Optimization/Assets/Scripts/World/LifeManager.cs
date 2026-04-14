using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] life;
    public GameObject player;

    private void Update()
    {
        if (!player.activeInHierarchy)
        {
            StartCoroutine(RespawnPlayer());
        }
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
    }
}
