using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public GameObject player;
    public GameObject monster;
    public GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (player == null || (player == null && monster == null))
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            gameOverScreen.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
