using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeLogic : MonoBehaviour
{
    public float pullForce = 10f; // Strength of the pull
    public float pullRadius = 5f; // Radius of effect
    public bool endGameOnPull = true; // Trigger game over when the player is pulled
    public float destroyDelay = 1.5f; // Delay before destroying pulled objects

    private bool isGameOver = false;

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate is running."); // Debug to check if FixedUpdate is executing

        // Find all colliders within the pull radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, pullRadius);
        Debug.Log($"Colliders detected within radius: {colliders.Length}"); // Debug to check the number of colliders detected

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log("Player detected within the pull radius."); // Debug when the player is detected
                PullPlayer(collider.gameObject);
            }
            else
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Debug.Log($"Pulling object: {collider.gameObject.name}"); // Debug to identify which objects are being pulled
                    PullObject(rb);
                }
                else
                {
                    Debug.Log($"Object without Rigidbody detected: {collider.gameObject.name}. Skipping pull."); // Debug for objects without Rigidbody
                }
            }
        }
    }

    private void PullPlayer(GameObject player)
    {
        Debug.Log("Pulling the player toward the black hole."); // Debug for player pull logic

        // Corrected: Ensure player moves toward the black hole
        Movement movementScript = player.GetComponent<Movement>();
        if (movementScript != null)
    {
        movementScript.enabled = false;
        Debug.Log("Player movement script disabled.");
    }
        Vector3 directionToBlackhole = (transform.position - player.transform.position).normalized;

        // Move the player closer to the black hole
        player.transform.position = Vector3.MoveTowards(
            player.transform.position,
            transform.position,
            pullForce * Time.deltaTime
        );

        Debug.Log($"Player's current distance from black hole: {Vector3.Distance(transform.position, player.transform.position)}"); // Debug for player's distance

        // Check if the player is consumed by the black hole
        if (Vector3.Distance(transform.position, player.transform.position) < 0.5f)
        {
            Debug.Log("Player reached the black hole's center."); // Debug when the player is consumed
            TriggerGameOver();
        }
    }

    private void PullObject(Rigidbody rb)
    {
        Debug.Log($"Pulling object with Rigidbody: {rb.gameObject.name}"); // Debug for pulling objects

        // Corrected: Ensure the force is pulling objects inward
        Vector3 directionToBlackhole = (transform.position - rb.position).normalized;

        // Apply force toward the black hole
        rb.AddForce(directionToBlackhole * pullForce, ForceMode.Acceleration);

        Debug.Log($"Object {rb.gameObject.name} is being pulled. Current distance: {Vector3.Distance(transform.position, rb.position)}"); // Debug for object's distance

        // Destroy objects that get too close to the black hole
        if (Vector3.Distance(transform.position, rb.position) < 0.5f)
        {
            Debug.Log($"Object {rb.gameObject.name} reached the black hole and will be destroyed."); // Debug when the object is destroyed
            Destroy(rb.gameObject, destroyDelay);
        }
    }

    private void TriggerGameOver()
    {
        Debug.Log("Game Over! You were consumed by the black hole!"); // Debug for game over trigger

        // Optional: Display game over UI or transition to a new scene
        if (!isGameOver)
        {
            Debug.Log("Transitioning to GameOverScene..."); // Debug for scene transition
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
            isGameOver = true;
        }

        // Optionally pause the game
        Time.timeScale = 0f; // Pause the game
        Debug.Log("Game is now paused."); // Debug for game pause
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the pull radius in the scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
        Debug.Log("Drawing gizmos for the black hole's pull radius."); // Debug for gizmo visualization
    }
}
