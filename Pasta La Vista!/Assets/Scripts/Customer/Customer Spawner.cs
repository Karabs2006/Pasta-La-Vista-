using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public Interact interact;
    public Transform spawnPoint;
    //public float spawnInterval = 30f;
    private float timer;
    private GameObject currentCustomer;


    void Update()
    {
        if (interact.nextCustomer)
        {
            SpawnCustomer();
            interact.nextCustomer = false;
        }
    }

    void SpawnCustomer()
    {
        currentCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);

        // Auto-assign spots
        Customer customer = currentCustomer.GetComponent<Customer>();
        customer.orderSpot = GameObject.Find("OrderSpot").transform;
        customer.exitSpot = GameObject.Find("ExitSpot").transform;
    }
}