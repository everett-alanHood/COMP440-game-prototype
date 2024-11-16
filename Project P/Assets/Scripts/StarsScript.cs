using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class StarsScript : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 0.75f;

    [SerializeField] 
    private CanvasRenderer stars;

    private float offset;


    // Start is called before the first frame update
    void Start()
    {
        stars.SetAlpha(0.0f);
   
    }  // end of Start() method

    // Update is called once per frame
    void Update()
    {
        offset = (Mathf.Sin(fadeSpeed * Time.time));

        // When offset is a negative #, the SetAlpha function interprets it as 0.
        // Because of this, the stars fade choppily (half of the Sine function is unused).
        // This if-statement accounts for when the Sine values dip into negative #s.

        if (offset < 0)
        {
            offset *= -1;

        }
        else { }

        stars.SetAlpha(offset);
    
    }  // end of Update() method

}  // end of class
