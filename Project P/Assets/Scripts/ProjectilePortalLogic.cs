using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePortalLogic : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile to shoot
    public Transform shootPoint;        // Position where projectiles are spawned
    public float shootInterval = 1f;    // Time between each shot
    public float projectileSpeed = 10f; // Speed of the projectiles

    private void Start()
    {
        // Start the shooting loop
        StartCoroutine(ShootProjectiles());
    }

    private IEnumerator ShootProjectiles()
    {
        while (true) // Infinite loop
        {
            Shoot();
            yield return new WaitForSeconds(shootInterval); // Wait before shooting again
        }
    }

    private void Shoot()
    {
        // Instantiate a projectile at the shoot point
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        // Add velocity to the projectile to make it move
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootPoint.forward * projectileSpeed;
        }

        Debug.Log("Projectile shot!");
    }
}
