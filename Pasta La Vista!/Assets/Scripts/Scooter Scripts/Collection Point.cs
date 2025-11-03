using UnityEngine;
using System.Collections;

public class CollectionPointStopSimple : MonoBehaviour
{
    public float stopTime = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scooter"))
        {
            StartCoroutine(StopScooter(other.gameObject));
        }
    }

    IEnumerator StopScooter(GameObject scooter)
    {
        

        // Stop the scooter by disabling its movement script temporarily
        ScooterConveyorMovement movement = scooter.GetComponent<ScooterConveyorMovement>();
        if (movement != null)
        {
            movement.enabled = false;

            // Wait
            yield return new WaitForSeconds(stopTime);

            // Resume
            movement.enabled = true;
          
        }
    }
}