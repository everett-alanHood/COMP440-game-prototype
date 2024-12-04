using UnityEngine;
using System.Collections; // Include this namespace for IEnumerator

public class AudioLooper : MonoBehaviour
{
    public AudioSource audioSource; // The audio source to play the clip
    public AudioClip washAwayClip; // The audio clip (wash_away.wav)

    private bool isLooping = false;
    private float loopStart = 3f; // Loop start time in seconds
    private float loopEnd = 5f; // Loop end time in seconds

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (washAwayClip != null)
        {
            audioSource.clip = washAwayClip;
        }
        else
        {
            Debug.LogError("Audio clip not assigned!");
        }
    }

    public void StartAudioLoop()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.time = 0f; // Start from the beginning
            audioSource.Play();
        }

        isLooping = true;
        StartCoroutine(LoopAudio());
    }

    public void StopAudioLoop()
    {
        isLooping = false;
        StartCoroutine(PlayReleaseAudio());
    }

    private IEnumerator LoopAudio()
    {
        while (isLooping)
        {
            if (audioSource.time >= loopEnd)
            {
                audioSource.time = loopStart; // Reset to loop start
            }
            yield return null; // Wait until the next frame
        }
    }

    private IEnumerator PlayReleaseAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.time = loopEnd; // Jump to the release segment
        }
        else
        {
            audioSource.time = loopEnd; // Set time directly for the final section
            audioSource.Play();
        }

        while (audioSource.time < audioSource.clip.length)
        {
            yield return null; // Wait until the release segment finishes
        }

        audioSource.Stop();
    }
}
