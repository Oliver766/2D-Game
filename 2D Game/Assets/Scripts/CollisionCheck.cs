using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private Animator animator;

    public int count;

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
            count = count +1;
            Debug.Log(count);
            count ++;
        }
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
