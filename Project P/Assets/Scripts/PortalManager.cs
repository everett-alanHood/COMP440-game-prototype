using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalManager : MonoBehaviour
{
    public Transform positionA;
    public Transform positionB;
    public Transform positionC;
    public Transform positionD;
    public Transform positionE;
    public Transform positionF;
    public AudioSource audio_src;
    public AudioClip teleportIN, teleportOUT;

    public Transform timeTravelPoint; // Time portal target

    private void OnTriggerEnter(Collider col)
    {
        CharacterController cc = GetComponent<CharacterController>();

        if (col.CompareTag("Portal A"))
        {
            audio_src.clip = teleportIN;
            audio_src.Play();

            Teleport(positionB, cc);
        }

        if (col.CompareTag("Portal B"))
        {
            audio_src.clip = teleportOUT;
            audio_src.Play();

            Teleport(positionA, cc);
        }

        if (col.CompareTag("Portal C"))
        {
            audio_src.clip = teleportIN;
            audio_src.Play();

            Teleport(positionD, cc);
        }

        if (col.CompareTag("Portal D"))
        {
            audio_src.clip = teleportOUT;
            audio_src.Play();

            Teleport(positionC, cc);
        }

        if (col.CompareTag("Portal E"))
        {
            audio_src.clip = teleportIN;
            audio_src.Play();

            Teleport(positionF, cc);
        }

        if (col.CompareTag("Portal F"))
        {
            audio_src.clip = teleportOUT;
            audio_src.Play();

            Teleport(positionE, cc);
        }

        if (col.CompareTag("TimePortal"))
        {
            Debug.Log("Time travel initiated!");
            Teleport(timeTravelPoint, cc); // Moves player to a specific past location
        }

    }

    private void Teleport(Transform targetPosition, CharacterController cc)
    {
        cc.enabled = false;
        transform.position = targetPosition.position;
        transform.rotation = new Quaternion(
            transform.rotation.x,
            targetPosition.rotation.y + 180f,
            transform.rotation.z,
            transform.rotation.w
        );
        cc.enabled = true;
    }

}
