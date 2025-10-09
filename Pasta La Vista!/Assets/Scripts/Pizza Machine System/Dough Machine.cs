using UnityEngine;

public class DoughMachine : MonoBehaviour
{
    public GameObject pizzaBasePrefab; // Pizza with only dough visible
    public float spawnInterval = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnPizzaBase();
            timer = 0f;
        }
    }

    void SpawnPizzaBase()
    {
        Instantiate(pizzaBasePrefab, transform.position, Quaternion.identity);
    }
}