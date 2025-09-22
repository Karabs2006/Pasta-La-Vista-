using UnityEngine;

/*Title: How to make a Car in Unity - Simple Car Controller
Author: Brackeys
Date Accessed: December 2023
Code Version: Unity 2019+ Compatible
Availability: https://www.youtube.com/watch?v=Z4HA8zJhGEk
*/
public class CarAI : MonoBehaviour
{
    public Transform exitPoint;
    public float speed = 5f;
    private float initialY; // Store initial height

    void Start()
    {
        // Store the starting height
        initialY = transform.position.y;
    }

    void Update()
    {
        // Move toward exit point but maintain Y position
        Vector3 targetPosition = exitPoint.position;
        targetPosition.y = initialY; // Keep original height

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        // Rotate to face exit (horizontal only)
        Vector3 lookDirection = exitPoint.position - transform.position;
        lookDirection.y = 0; // Ignore vertical difference
        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        // Destroy when reached exit
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            Destroy(gameObject);
        }
    }
}