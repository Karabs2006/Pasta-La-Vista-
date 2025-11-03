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
        // Spawn scooter at spawn point
        GameObject scooter = Instantiate(scooterPrefab, spawnPoint.position, spawnPoint.rotation);

        // Set the land point
        ScooterMovement movement = scooter.GetComponent<ScooterMovement>();
        if (movement != null)
        {
            movement.SetLandPoint(landPoint);
        }

        Debug.Log("Spawned scooter moving to land point");
    }
}