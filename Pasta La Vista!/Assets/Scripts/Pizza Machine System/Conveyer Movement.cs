using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float beltSpeed = 2f;

    void OnTriggerStay(Collider other)
    {
        // Move any pizza object forward
        if (other.CompareTag("Pizza"))
        {
            other.transform.Translate(Vector3.forward * beltSpeed * Time.deltaTime);
        }
    }
}