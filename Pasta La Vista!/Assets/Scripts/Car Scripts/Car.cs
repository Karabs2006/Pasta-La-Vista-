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
      
        initialY = transform.position.y;
    }

    void Update()
    {
        
        Vector3 targetPosition = exitPoint.position;
        targetPosition.y = initialY; // Keep original height

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

    
        Vector3 lookDirection = exitPoint.position - transform.position;
        lookDirection.y = 0; 
        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

       
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            Destroy(gameObject);
        }
    }
}