using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private Animator animator;

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
        }
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
