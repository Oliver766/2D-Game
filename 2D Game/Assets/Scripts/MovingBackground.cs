using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script reference - sloo  - https://www.youtube.com/watch?v=4MCAYdhu5LY
// script by oliver lancashire
// sid - 1901981
public class MovingBackground : MonoBehaviour
{
    [Header("Game object")]
    public GameObject camera;
    [Header("Floats")]
    public float parallexEffect;
    private float width, positionX;

    void Start()
    {
        // gets the width component of sprite 
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        // set position of the x position
        positionX = transform.position.x;
    }

    void Update()
    {
        // set float of x position times the parallex effect
        float parallaxDistance = camera.transform.position.x * parallexEffect;
        // set float of x position and one minus  the parallex effect
        float remainingDistance = camera.transform.position.x * (1 - parallexEffect);
        // set position with new vector 3 
        transform.position = new Vector3(positionX + parallaxDistance, transform.position.y, transform.position.z);
        // checks remaining distance and get variable number
        if(remainingDistance > positionX + width)
        {
            positionX += width;
        }
    }
}
