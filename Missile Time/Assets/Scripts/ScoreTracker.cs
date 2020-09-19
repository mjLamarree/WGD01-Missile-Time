using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    public int scoreTracker;
    public GameObject player;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreTracker = 0;
        scoreText.GetComponent<TextMeshProUGUI>().text = "0";
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.GetComponent<TextMeshProUGUI>().text = scoreTracker.ToString();

        if(player != null)
        {
            scoreTracker = player.GetComponent<PlayerController>().jumpScore;
        }

    }
}
