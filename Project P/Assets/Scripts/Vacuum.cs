using UnityEngine;
using UnityEngine.Events;

public class Vacuum : MonoBehaviour
{
    public UnityEvent onShoot;

    void Start()
    {
        // Automatically find the BlastDetect script and bind the Shoot method
        SuckDetect suckDetect = FindObjectOfType<SuckDetect>();
        if (suckDetect != null)
        {
            onShoot.AddListener(suckDetect.Shoot);
            Debug.Log("Shoot method bound to onShoot event.");
        }
        else
        {
            Debug.LogError("SuckDetect script not found in the scene.");
        }
    }

    void Update()
    {
        // Check if the right mouse button is pressed
        if (Input.GetMouseButton(1)) // Trigger on a single click
        {
            Debug.Log("Right mouse button clicked.");
            onShoot?.Invoke();
        }
    }
}
