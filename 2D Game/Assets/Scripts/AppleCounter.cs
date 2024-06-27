using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCounter : MonoBehaviour
{
    public void  OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player"){

            Debug.Log("You are dead");
            Time.timeScale = 0;
        }
    }
}
