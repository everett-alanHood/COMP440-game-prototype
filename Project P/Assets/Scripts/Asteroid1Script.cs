using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Script : MonoBehaviour
{
    public float maxMomentum;
    public float minMomentum;
    public float maxSpin;
    public float minSpin;
    public Rigidbody2D asteroid;

    // positions of screen borders
    public float topBorder;
    public float bottomBorder;
    public float leftBorder;
    public float rightBorder;

    // Start is called before the first frame update
    void Start()
    {
        // Gives asteroid a random amount of momentum; generates a random vector
        Vector3 momentum = new Vector3(Random.Range(minMomentum, maxMomentum), Random.Range(minMomentum, maxMomentum), 0);
        
        // Gives asteroid a random amount spin speed
        float spin = Random.Range(minSpin, maxSpin);

        asteroid.AddForce(momentum);
        asteroid.AddTorque(spin);

    } // end Start() method 

    // Update is called once per frame
    void Update()
    {
        // Causes asteroid to wrap around screen
        
        /* Vector3 newPos = asteroid.position;

        if (asteroid.position.x > rightBorder)
        {
            newPos.x = leftBorder;
            asteroid.position = newPos;

        }
        else if (asteroid.position.x < leftBorder)
        {
            newPos.x = rightBorder;
            asteroid.position = newPos;

        }
        else if (asteroid.position.y > topBorder)
        {
            newPos.y = bottomBorder;
            asteroid.position = newPos;

        }
        else if (asteroid.position.y < bottomBorder)
        {
            newPos.y = topBorder;
            asteroid.position = newPos;

        }
        else { } */

    }
}
