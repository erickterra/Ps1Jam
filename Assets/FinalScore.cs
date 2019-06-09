using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalScore : MonoBehaviour
{
    private int score;
    private Score playerScore;

    private Text scoreText;
    private float Best, Last;


    private void Awake()
    {
        playerScore = GameObject.FindWithTag("Player").GetComponent<Score>();
        scoreText = GetComponent<Text>();
        Best = PlayerPrefs.GetFloat("HighScore");
        Last = PlayerPrefs.GetFloat("LastTime");
    }

    private void LateUpdate()
    {
        score = playerScore.currentScore;
        scoreText.text = "Your Time: " + Last.ToString("00.00") + "\nBest: " + Best.ToString("00.00");
    }
}
