using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet1Script : MonoBehaviour
{
    [SerializeField]  // makes the below value editable in the Unity editor
    float frequency = 1f;  // wavelength of sine wave; determines speed of bobbing
    
    [SerializeField]
    float amplitude = 0.25f;  // determines peak and lowest points of movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // putting scalar operands first and vector operands last increases efficiency
        // scalar math is faster than vector math
        transform.position += amplitude * Mathf.Sin(frequency * Time.time) * transform.up;

        /* 
           Time.time is used instead of Time.deltaTime because, in order for the sine function
           to work as intended, we need a CONSTANT angle (time since application started).
           Time.deltaTime is NOT constant, as its angle depends on hardware capabilities & FPS.
        */
    }
}
