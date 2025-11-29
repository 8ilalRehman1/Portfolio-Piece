using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource whatSong;
    public AudioClip songOne;
    private void Start()
    {
        whatSong.clip = songOne;
        whatSong.Play();
    }
}
