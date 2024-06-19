using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private Animator animator;

    public int coinCollected;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Coin collected!");
            animator.SetTrigger("Collected");
            coinCollected = coinCollected +1;
           Debug.Log(coinCollected);

        }
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
