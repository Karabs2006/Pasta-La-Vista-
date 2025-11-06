using UnityEngine;
using System.Collections;

public class ScooterConveyorMovement : MonoBehaviour
{
    public float conveyorSpeed = 3f;
    public float waitTime = 0f;

    private bool isOnConveyor = false;
    private bool hasWaited = false;

    void Update()
    {

        if (isOnConveyor && hasWaited)
        {
            transform.Translate(Vector3.forward * conveyorSpeed * Time.deltaTime, Space.World);
        }
    }

    public void StartConveyorMovement()
    {
        StartCoroutine(WaitThenMove());
    }

    IEnumerator WaitThenMove()
    {

        
        yield return new WaitForSeconds(waitTime);

        // Start moving on conveyor
        hasWaited = true;
        isOnConveyor = true;
        
    }
}