using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LifeManager : MonoBehaviour
{
    public GameObject[] life;
    public int currentLives;
    public GameObject player;
    public PlayerInput playerInput;

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
        if (currentLives >= 0)
        {
            
            life[currentLives].SetActive(false);
            player.SetActive(true);
            playerInput.enabled = true;
        }
    }
}
