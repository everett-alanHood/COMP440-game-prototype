using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalManager : MonoBehaviour
{
    public Transform positionA;
    public Transform positionB;
    public AudioSource audio_src;
    public AudioClip teleportIN, teleportOUT;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Portal A")){
            CharacterController cc = GetComponent<CharacterController>();

            audio_src.clip = teleportIN;
            audio_src.Play();

            cc.enabled = false;
            transform.position = positionB.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, positionB.rotation.y, transform.rotation.z, transform.rotation.w);

            cc.enabled = true;
        }

        if (col.CompareTag("Portal B")){
            CharacterController cc = GetComponent<CharacterController>();
            
            audio_src.clip = teleportOUT;
            audio_src.Play();
            
            cc.enabled = false;
            transform.position = positionA.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, positionA.rotation.y, transform.rotation.z, transform.rotation.w);

            cc.enabled = true;
        }
    }
}

