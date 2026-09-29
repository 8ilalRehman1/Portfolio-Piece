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

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    } //there is mulitple music so the funciton should take a parameter
    //the rest of the sounds are only played within the main game and there is only one sound per function

    public void PlayCoinSFX()
    {
        coinSFXsource.clip = coinSFXclip;
        coinSFXsource.Play();
    }

    public void PlayEnemyDeathSound()
    {
        enemyDeathNoise.clip = enemyDeathClip;
        enemyDeathNoise.Play();
    }

    public void PlayPlayerDeathSound()
    {
        playerDeathNoise.clip = playerDeathClip;
        playerDeathNoise.Play();
    }
}
