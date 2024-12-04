using UnityEngine;
using UnityEngine.Events;

public class PowerWasher : MonoBehaviour
{
    public UnityEvent onShoot;
    public UnityEvent onRelease;
    private PushDetect pushDetect;
    private AudioLooper audioLooper;

    void Start()
    {
        pushDetect = FindObjectOfType<PushDetect>();
        audioLooper = FindObjectOfType<AudioLooper>();

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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked.");
            onShoot?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Left mouse button released.");
            onRelease?.Invoke();
        }
    }
}
