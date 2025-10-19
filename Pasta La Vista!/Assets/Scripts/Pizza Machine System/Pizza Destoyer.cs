using UnityEngine;

public class PizzaDestroyer : MonoBehaviour
{
    public float destroyDelay = 2f; // Small delay at the end

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Debug.Log("Pizza reached destroy trigger! Destroying in " + destroyDelay + " seconds");

            // Destroy the entire pizza object after delay
            Destroy(other.gameObject, destroyDelay);
        }
    }
}