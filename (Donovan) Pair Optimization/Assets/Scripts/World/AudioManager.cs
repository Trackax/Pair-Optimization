using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip fire;
    public AudioClip enemyDie;
    public AudioClip playerDie;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void EnemyDie()
    {
        source.PlayOneShot(enemyDie);
    }

    public void PlayerDie()
    {
        source.PlayOneShot(playerDie);
    }
}
