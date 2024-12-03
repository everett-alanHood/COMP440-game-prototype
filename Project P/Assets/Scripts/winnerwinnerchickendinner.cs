using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required to load scenes

public class winnerwinnerchickendinner : MonoBehaviour
{
    public string winTag = "WinCondition"; // Tag to identify projectiles
    public string gameWinScene = "GameWinScene"; // Scene to load on game over

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag(winTag))
        {
            Debug.Log("Player has ESCAPED?!");
            WinGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger detected with: {other.gameObject.name}");

        if (other.CompareTag(winTag))
        {
            Debug.Log("Player hit by a projectile (trigger). Game over!");
            WinGame();
        }
    }

    private void WinGame()
    {
        Debug.Log("Ending the game...");
        // Ensure the scene exists in Build Settings
        SceneManager.LoadScene(gameWinScene);
    }
}
