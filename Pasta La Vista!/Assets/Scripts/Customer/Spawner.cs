using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject customerPrefab;  // Will assign in Inspector
    public Transform spawnPoint;      // Will assign in Inspector

    void Start()
    {
        // Spawn one customer when game starts
        SpawnCustomer();
    }

    void SpawnCustomer()
    {
        if (customerPrefab != null && spawnPoint != null)
        {
            Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("Spawned a customer!");
        }
        else
        {
            Debug.LogError("Missing prefab or spawn point!");
        }
    }
}