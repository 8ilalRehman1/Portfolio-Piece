using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuToGame : MonoBehaviour
{
    public string sceneName;
    public AudioSource whatSong;
    public AudioClip songOne;
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    private void Start()
    {
        whatSong.clip = songOne;
        whatSong.Play();
    }
}
