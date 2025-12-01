using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDyingSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip enemyDying;
    private void Start()
    {
        audioSource.clip = enemyDying;
    }
    private void OnDestroy()
    {

        audioSource.Play();
    }
}
