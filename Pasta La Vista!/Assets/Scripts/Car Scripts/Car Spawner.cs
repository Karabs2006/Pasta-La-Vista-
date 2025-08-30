using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform spawnPoint;
    public Transform exitPoint;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;

    private float nextSpawnTime;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCar();
            SetNextSpawnTime();
        }
    }

    void SpawnCar()
    {
        GameObject car = Instantiate(carPrefab, spawnPoint.position, Quaternion.identity);

        // Set exit point for this car
        CarAI carAI = car.GetComponent<CarAI>();
        carAI.exitPoint = exitPoint;
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }
}
