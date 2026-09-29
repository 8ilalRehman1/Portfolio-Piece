using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource coinSFXsource;
    [SerializeField] AudioSource enemyDeathNoise;
    [SerializeField] AudioSource playerDeathNoise;
    [SerializeField] AudioClip coinSFXclip;
    [SerializeField] AudioClip enemyDeathClip;
    [SerializeField] AudioClip playerDeathClip;
    [SerializeField] AudioClip musicClip;
    //all of the variables for the sounds
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            //deletes any other instance of audio manager
        }
    }

    public void PlayMusic()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    } 

    public void PlayCoinSFX()
    {
        coinSFXsource.clip = coinSFXclip;
        coinSFXsource.Play();
    }

    public void PlayEnemyDeathSound()
    {
        enemyDeathNoise.clip = enemyDeathClip;
        enemyDeathNoise.Play();
        if (enemyDeathNoise == null)
        {
            enemyDeathNoise.Stop();
        }
    }

    public void PlayPlayerDeathSound()
    {
        playerDeathNoise.clip = playerDeathClip;
        playerDeathNoise.Play();
    }
}
