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

    // LOCAL positions of screen borders (relative to the parent GameObject: Canvas)
    
    public float topBorder = 623;  // y = 623
    public float bottomBorder = -623; // y = -623
    public float leftBorder = -998;  // x = -998
    public float rightBorder = 1089;  // x = 1089

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
        
        Vector3 newPos = transform.localPosition;

        if (transform.localPosition.x > rightBorder)
        {
            newPos.x = leftBorder;
            transform.localPosition = newPos;

        }
        else if (transform.localPosition.x < leftBorder)
        {
            newPos.x = rightBorder;
            transform.localPosition = newPos;

        }
        else if (transform.localPosition.y > topBorder)
        {
            newPos.y = bottomBorder;
            transform.localPosition = newPos;

        }
        else if (transform.localPosition.y < bottomBorder)
        {
            newPos.y = topBorder;
            transform.localPosition = newPos;

        }
        else { }

    }  // end of Update() method

}  // end of class
