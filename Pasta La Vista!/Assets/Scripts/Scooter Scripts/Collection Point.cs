/* Title: Unity Triggers and Collision Detection
Author: Brackeys
Date Accessed: 25 October 2025
Code Version: Unity 2019+ Compatible
Availability: https://www.youtube.com/watch?v=gAB64vfbrhI
*/

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
        ScooterConveyorMovement movement = scooter.GetComponent<ScooterConveyorMovement>();
        if (movement != null)
        {
            movement.enabled = false;

           
            yield return new WaitForSeconds(stopTime);

 
            movement.enabled = true;
          
        }
    }
}