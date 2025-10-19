using UnityEngine;


public class DoughMachine : MonoBehaviour
{
    public GameObject pizzaPrefab;
  
    public float spawnTime = 3f;
    private float timer;

    void Start()
    {
        // Spawn first pizza immediately
        SpawnPizza();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            SpawnPizza();
            timer = 0f;
        }
    }

    void SpawnPizza()
    {
        if (pizzaPrefab != null)
        {
            Instantiate(pizzaPrefab, transform.position, Quaternion.identity);

        }
    }
}