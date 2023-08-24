using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] Transform Player = null;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponent<PlayerMovement>().isDead = true;
            Player.GetComponent<MB_PlayerMovement>().isDead = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        //Player.GetComponent<PlayerMovement>().enabled = true;
    }
}
