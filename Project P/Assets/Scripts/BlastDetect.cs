using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastDetect : MonoBehaviour
{
    public GameObject User; // The "gun"
    public float range = 100f; // The range of the raycast
    public float pullForce = -5f; // Force used to attract the item
    public float damping = 0.95f; // Damping factor to slow the item down gradually
    public float stopThreshold = 0.1f; // Distance at which the object stops completely

    private Transform playerCam;
    private Rigidbody item;
    private GameObject currentItem;
    private bool isPulling = false;

    void Start()
    {
        // Find the PlayerCam by name or tag
        GameObject playerCamObject = GameObject.Find("PlayerCam");
        if (playerCamObject != null)
        {
            playerCam = playerCamObject.transform;
            Debug.Log("PlayerCam found and assigned.");
        }
        else
        {
            Debug.LogError("PlayerCam not found.");
        }
    }

    public void Shoot()
{
    if (playerCam == null) return; // Exit if the PlayerCam isn't assigned

    Ray toolRay = new Ray(playerCam.position, playerCam.forward);
    Debug.DrawRay(playerCam.position, playerCam.forward * range, Color.red, 1f);

    if (Physics.Raycast(toolRay, out RaycastHit hitInfo, range))
    {
        Debug.Log("Raycast hit: " + hitInfo.collider.gameObject.name);

        // Skip blackhole or other objects you don't want to pull
        if (hitInfo.collider.gameObject.CompareTag("BlackholePortal"))
        {
            Debug.Log("Hit a Blackhole, skipping pull.");
            return;
        }

        // Check if the hit object has an Entity component
        if (hitInfo.collider.gameObject.TryGetComponent<Entity>(out Entity portals))
        {
            Debug.Log("Entity detected: " + portals.gameObject.name);
            currentItem = portals.gameObject; // Assign the hit portal as the current item

            // Ensure the item has a Rigidbody
            if (!currentItem.TryGetComponent<Rigidbody>(out item))
            {
                item = currentItem.AddComponent<Rigidbody>();
            }

            item.useGravity = false; // Disable gravity for smoother pulling
            isPulling = true; // Start pulling the item
        }
        else
        {
            Debug.LogWarning("Hit object does not have an Entity component.");
        }
    }
    else
    {
        Debug.LogWarning("Raycast did not hit any object.");
    }
}


    public void Release()
    {
        if (currentItem != null && item != null)
        {
            isPulling = false;
            item.velocity *= damping; // Apply damping to reduce velocity
            Debug.Log("Released the item, applying damping.");
        }
    }

    void Update()
    {
        // If pulling, apply force to attract the item to the User
        if (isPulling && currentItem != null && item != null)
        {
            Vector3 direction = (User.transform.position - currentItem.transform.position).normalized;
            float distance = Vector3.Distance(User.transform.position, currentItem.transform.position);

            // Apply a force toward the User
            item.AddForce(direction * pullForce, ForceMode.Acceleration);

            // Stop pulling if the object is close enough to the User
            if (distance < stopThreshold)
            {
                isPulling = false;
                item.velocity = Vector3.zero; // Stop motion completely
                Debug.Log("Item has reached the target position.");
            }
        }

        // Apply gradual slowdown when released
        if (!isPulling && item != null)
        {
            item.velocity *= damping; // Apply damping to gradually slow down
            if (item.velocity.magnitude < 0.01f)
            {
                item.velocity = Vector3.zero; // Stop completely when very slow
            }
        }

        // Releasing hold
        if (Input.GetMouseButtonUp(0))
        {
            Release();
        }
    }
}
