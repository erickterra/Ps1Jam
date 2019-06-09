using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [HideInInspector]
   public int currentScore, totalScore = 0;
   private bool LOADED = false;


   private void Awake() 
   {
       DontDestroyOnLoad(this);
       currentScore = 0;
       totalScore = 0;
   }

   private void Update() 
   {
       if (currentScore == totalScore && !LOADED)
       {
           if (Time.time < PlayerPrefs.GetFloat("HighScore"))
           {
                PlayerPrefs.SetFloat("HighScore", Time.time);
           }
           PlayerPrefs.SetFloat("LastTime", Time.time);
           SceneManager.LoadScene("GameOver");
           LOADED = true;
       }
   }

   public void IncreaseScore(int amount)
   {
       currentScore += amount;
   }

   public void DecreaseScore(int amount)
   {
       currentScore -= amount;
   }

   public void Count(int amount)
   {
       totalScore += amount;
   }
   
}
