using UnityEngine;

public class ConveyorBelt1 : MonoBehaviour
{
    public float beltSpeed = 2f;

    void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Pizza"))
        {
            other.transform.Translate(Vector3.forward * beltSpeed * Time.deltaTime);
        }
    }
}