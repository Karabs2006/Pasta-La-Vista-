using UnityEngine;

public class PizzaDestroyer : MonoBehaviour
{
    public float destroyDelay = 2f; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Debug.Log("Pizza reached destroy trigger! Destroying in " + destroyDelay + " seconds");

            
            Destroy(other.gameObject, destroyDelay);
        }
    }
}