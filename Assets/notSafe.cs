using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notSafe : MonoBehaviour
{

    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player.isSafe = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.isSafe = true;
        }
    }
}
