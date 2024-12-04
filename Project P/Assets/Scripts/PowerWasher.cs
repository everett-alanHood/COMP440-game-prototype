using UnityEngine;
using UnityEngine.Events;

public class PowerWasher : MonoBehaviour
{
    public UnityEvent onShoot;
<<<<<<< HEAD
    public UnityEvent onRelease;

    private PushDetect pushDetect;

    void Start()
    {
        // Automatically find the PushDetect script
        pushDetect = FindObjectOfType<PushDetect>();
        if (pushDetect != null)
=======

    void Start()
    {
        // Automatically find the BlastDetect script and bind the Shoot method
        BlastDetect blastDetect = FindObjectOfType<BlastDetect>();
        if (blastDetect != null)
>>>>>>> parent of 178ddeb (Merge pull request #1 from everett-alanHood/main)
        {
            onShoot.AddListener(blastDetect.Shoot);
            Debug.Log("Shoot method bound to onShoot event.");
        }
        else
        {
            Debug.LogError("BlastDetect script not found in the scene.");
        }
    }

    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        if (Input.GetMouseButtonDown(0))
=======
        // Check if the left mouse button is pressed
        if (Input.GetMouseButton(0)) // Trigger on a single click
>>>>>>> parent of 178ddeb (Merge pull request #1 from everett-alanHood/main)
=======
        // Trigger pulling on left mouse button hold
        if (Input.GetMouseButtonDown(0)) // Start pushing
>>>>>>> parent of bd0cb9a (Test)
        {
            Debug.Log("Left mouse button clicked.");
            onShoot?.Invoke();
        }
<<<<<<< HEAD

        // Release pulling on left mouse button release
        if (Input.GetMouseButtonUp(0)) // Stop pushing
        {
            Debug.Log("Left mouse button released.");
            onRelease?.Invoke();
        }
=======
>>>>>>> parent of 178ddeb (Merge pull request #1 from everett-alanHood/main)
    }
}
