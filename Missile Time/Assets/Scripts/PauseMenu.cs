using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseScreen;
    private bool isGamePaused = false;

    private void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused) { Pause(); } else { Resume(); }
        }
        
    }

    void Pause()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
        isGamePaused = true;
    }

    void Resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        isGamePaused = false;
    }

}
