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
    public GameObject gameOverScreen;
    public GameObject game;

    private void Update()
    {
        if (!player.activeInHierarchy)
        {
            StartCoroutine(RespawnPlayer());
        }
        if (currentLives < 0)
        {
            gameOverScreen.SetActive(true);
            game.SetActive(false);
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
