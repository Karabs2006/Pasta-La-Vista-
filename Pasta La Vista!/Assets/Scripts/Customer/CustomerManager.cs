using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    // Assign these in Inspector
    public GameObject customerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 30f;

    private float timer;
    private GameObject currentCustomer;

    void Update()
    {
        timer += Time.deltaTime;

        // Only spawn new customer if none exists
        if (timer >= spawnDelay && currentCustomer == null)
        {
            SpawnNewCustomer();
            timer = 0f;
        }
    }

    void SpawnNewCustomer()
    {
        // Safety checks
        if (customerPrefab == null)
        {
            Debug.LogError("Customer prefab not assigned!");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("Spawn point not assigned!");
            return;
        }

        currentCustomer = Instantiate(
            customerPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        // Auto-assign customer's movement targets
        Customer customerScript = currentCustomer.GetComponent<Customer>();
        if (customerScript != null)
        {
            customerScript.orderSpot = GameObject.Find("OrderSpot")?.transform;
            customerScript.exitSpot = GameObject.Find("ExitSpot")?.transform;
        }
    }

    public void CustomerLeft()
    {
        currentCustomer = null;
    }
}