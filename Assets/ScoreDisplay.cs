using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
   private int score;
   private Score playerScore;

   private Text scoreText;
   private float Best;


   private void Awake() 
   {
       playerScore = GameObject.FindWithTag("Player").GetComponent<Score>();
       scoreText = GetComponent<Text>();
    Best = PlayerPrefs.GetFloat("HighScore");
   }

   private void LateUpdate() 
   {
       score = playerScore.currentScore;
       scoreText.text = "Score: " + score.ToString() + "/" + playerScore.totalScore.ToString() + "\nTime: " + Time.time.ToString("00.00") + "\nBest: " + Best.ToString("00.00");
   }
}
