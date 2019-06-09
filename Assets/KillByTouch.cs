using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillByTouch : MonoBehaviour
{
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            player.PlayerDie();
            player.isSafe = false;
        }
    }

}
