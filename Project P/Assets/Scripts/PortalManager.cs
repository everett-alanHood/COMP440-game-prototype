using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalManager : MonoBehaviour
{
    public Transform positionA;
    public Transform positionB;
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
