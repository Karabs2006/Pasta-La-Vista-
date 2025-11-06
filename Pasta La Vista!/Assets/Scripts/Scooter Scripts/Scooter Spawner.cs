/*Title: Working with Prefabs in Unity - Instantiate and Destroy
Author: Unity Technologies
Date Accessed: 15 October 2025
Code Version: Unity 2021+ Compatible
Availability: https://www.youtube.com/watch?v=6dVRB7aAaEI
*/

using UnityEngine;

public class ScooterSpawner : MonoBehaviour
{
    public GameObject scooterPrefab;
    public Transform spawnPoint;
    public Transform landPoint;
    public float spawnInterval = 5f;

    void Start()
    {
        SpawnScooter();
        InvokeRepeating("SpawnScooter", spawnInterval, spawnInterval);
    }

    void SpawnScooter()
    {
        
        GameObject scooter = Instantiate(scooterPrefab, spawnPoint.position, spawnPoint.rotation);

        // Set the land point
        ScooterMovement movement = scooter.GetComponent<ScooterMovement>();
        if (movement != null)
        {
            movement.SetLandPoint(landPoint);
        }
    }
}