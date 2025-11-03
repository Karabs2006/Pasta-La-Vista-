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
        Debug.Log("Ascend Point: Scooter starting ascent");

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

        // Destroy scooter
        if (scooter != null)
        {
            Destroy(scooter);
            Debug.Log("Scooter deleted at delete point");
        }
    }
}