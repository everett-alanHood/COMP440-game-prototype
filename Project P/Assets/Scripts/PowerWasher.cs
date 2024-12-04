using UnityEngine;
using UnityEngine.Events;

public class PowerWasher : MonoBehaviour
{
    public UnityEvent onShoot;
<<<<<<< HEAD
    public UnityEvent onRelease;
    private PushDetect pushDetect;
    private AudioLooper audioLooper;

    void Start()
    {
        pushDetect = FindObjectOfType<PushDetect>();
        audioLooper = FindObjectOfType<AudioLooper>();

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

        if (audioLooper != null)
        {
            onShoot.AddListener(audioLooper.StartAudioLoop);
            onRelease.AddListener(audioLooper.StopAudioLoop);
        }
        else
        {
            Debug.LogError("AudioLooper script not found in the scene.");
        }
    }

    void Update()
    {
<<<<<<< HEAD
        if (Input.GetMouseButtonDown(0))
=======
        // Check if the left mouse button is pressed
        if (Input.GetMouseButton(0)) // Trigger on a single click
>>>>>>> parent of 178ddeb (Merge pull request #1 from everett-alanHood/main)
        {
            Debug.Log("Left mouse button clicked.");
            onShoot?.Invoke();
        }
<<<<<<< HEAD

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Left mouse button released.");
            onRelease?.Invoke();
        }
=======
>>>>>>> parent of 178ddeb (Merge pull request #1 from everett-alanHood/main)
    }
}
