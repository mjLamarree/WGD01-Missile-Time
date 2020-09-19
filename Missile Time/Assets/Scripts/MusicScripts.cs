using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScripts : MonoBehaviour
{
    public AudioSource music;
    public GameObject canvas;
    public AudioClip[] songs;

    private int count = 0;

    private void Awake()
    {
        music.clip = songs[1];
        music.loop = true;
        music.Play();
    }

    void Update()
    {
        if (canvas.GetComponentInChildren<GameOverScreen>().playerLose && count == 0)
        {
            GameOver();
        }
        if (canvas.GetComponentInChildren<WinScreen>().playerWin && count == 0)
        {
            GameWon();
        }
    }

    public void GameOver()
    {
        music.loop = false;
        music.Stop();
        music.clip = songs[0];
        music.Play();
        count++;
    }

    public void GameWon()
    {
        music.Stop();
        music.clip = songs[2];
        music.Play();
        count++;
    }

}
