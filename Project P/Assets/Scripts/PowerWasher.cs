using UnityEngine;
using UnityEngine.Events;

public class PowerWasher : MonoBehaviour
{
    public UnityEvent onShoot;
    public UnityEvent onRelease;

    private PushDetect pushDetect;

    void Start()
    {
        // Automatically find the PushDetect script
        pushDetect = FindObjectOfType<PushDetect>();
        if (pushDetect != null)
        {
            onShoot.AddListener(pushDetect.Shoot);
            onRelease.AddListener(pushDetect.Release);
            Debug.Log("Shoot and Release methods bound to events.");
        }
        else
        {
            Debug.LogError("PushDetect script not found in the scene.");
        }
    }

    void Update()
    {
        // Trigger pulling on left mouse button hold
        if (Input.GetMouseButtonDown(0)) // Start pushing
        {
            Debug.Log("Left mouse button clicked.");
            onShoot?.Invoke();
        }

        // Release pulling on left mouse button release
        if (Input.GetMouseButtonUp(0)) // Stop pushing
        {
            Debug.Log("Left mouse button released.");
            onRelease?.Invoke();
        }
    }
}
