using UnityEngine;
using UnityEngine.Events;

public class PowerWasher : MonoBehaviour
{
    public UnityEvent onShoot;

    void Start()
    {
        // Automatically find the BlastDetect script and bind the Shoot method
        BlastDetect blastDetect = FindObjectOfType<BlastDetect>();
        if (blastDetect != null)
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
        // Check if the right mouse button is pressed
        if (Input.GetMouseButton(0)) // Trigger on a single click
        {
            Debug.Log("Left mouse button clicked.");
            onShoot?.Invoke();
        }
    }
}
