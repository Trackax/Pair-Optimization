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
    public GameObject gameMusic;
    bool isRespawning;

    private void Update()
    {
        if (!player.activeInHierarchy && !isRespawning)
        {
            StartCoroutine(RespawnPlayer());
        }
        if (currentLives < 0)
        {
            gameOverScreen.SetActive(true);
            game.SetActive(false);
            gameMusic.SetActive(false);
        }
    }


    // optimization 3: added a boolean to prevent coroutine from being started hundreds of times
    private IEnumerator RespawnPlayer()
    {
        isRespawning = true;
        yield return new WaitForSeconds(2f);
        isRespawning = false;
        if (currentLives >= 0)
        {
            life[currentLives].SetActive(false);
            player.SetActive(true);
            playerInput.enabled = true;
        }
    }
}
