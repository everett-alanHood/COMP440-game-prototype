using UnityEngine;
using UnityEngine.Events;

public class Vacuum : MonoBehaviour
{
    public UnityEvent onShoot;
    public UnityEvent onRelease;

    private PullDetect pullDetect;

    void Start()
    {
        // Automatically find the PullDetect script
        pullDetect = FindObjectOfType<PullDetect>();
        if (pullDetect != null)
        {
            onShoot.AddListener(pullDetect.Shoot);
            onRelease.AddListener(pullDetect.Release);
            Debug.Log("Shoot and Release methods bound to events.");
        }
        else
        {
            Debug.LogError("PullDetect script not found in the scene.");
        }
    }

    void Update()
    {
        // Trigger pulling on right mouse button hold
        if (Input.GetMouseButtonDown(1)) // Start pulling
        {
            Debug.Log("Right mouse button clicked.");
            onShoot?.Invoke();
        }

        // Release pulling on right mouse button release
        if (Input.GetMouseButtonUp(1)) // Stop pulling
        {
            Debug.Log("Right mouse button released.");
            onRelease?.Invoke();
        }
    }
}
