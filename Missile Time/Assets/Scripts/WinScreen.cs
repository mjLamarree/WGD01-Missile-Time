using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public GameObject winScreen;
    public GameObject scoreText;
    public bool playerWin;

    private void Start()
    {
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (monster == null && player != null)
        {
            playerWin = true;
            scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + GetComponent<ScoreTracker>().scoreTracker.ToString();
            winScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            winScreen.SetActive(false);
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
