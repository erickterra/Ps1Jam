using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreByTouch : MonoBehaviour
{
   public int value = 1;
   private Score pontos;
   private int total;

   private void Awake() 
   {
        pontos = GameObject.FindWithTag("Player").GetComponent<Score>();
        pontos.Count(value);
   }

   private void OnTriggerEnter(Collider other) 
   {
       if (other.tag == "Player")
       {
           pontos.IncreaseScore(value);
           Destroy(gameObject);
       }
   }
}
