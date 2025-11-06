/*Title: Unity Coroutines Tutorial - WaitForSeconds, Start, Stop
Author: Brackeys
Date Accessed: 25 October 2025
Code Version: Unity 2019+ Compatible
Availability: https://www.youtube.com/watch?v=Qxs3GrhcZIEN
*/ 

using UnityEngine;
using System.Collections;

public class AscendTrigger : MonoBehaviour
{
    public float ascendSpeed = 8f;
    public Transform deletePoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scooter"))
        {
            StartCoroutine(AscendScooter(other.gameObject));
        }
    }

    IEnumerator AscendScooter(GameObject scooter)
    {
       

        // Disable conveyor movement
        ScooterConveyorMovement movement = scooter.GetComponent<ScooterConveyorMovement>();
        if (movement != null)
        {
            movement.enabled = false;
        }

        // Ascend to delete point
        while (scooter != null && Vector3.Distance(scooter.transform.position, deletePoint.position) > 0.1f)
        {
            scooter.transform.position = Vector3.MoveTowards(
                scooter.transform.position,
                deletePoint.position,
                ascendSpeed * Time.deltaTime
            );
            yield return null;
        }

     
        if (scooter != null)
        {
            Destroy(scooter);
          
        }
    }
}