using UnityEngine;

public class Customer : MonoBehaviour
{
    // Set these in Inspector
    public Transform orderSpot;
    public Transform exitSpot;
    public float moveSpeed = 2f;

    private bool orderTaken = false;
    private bool hasPizza = false;


    private void Start()
    {
        orderSpot = GameObject.FindWithTag("Order Spot").transform;
        exitSpot = GameObject.FindWithTag("Exit Spot").transform;
    }
    void Update()
    {
        if (!orderTaken)
        {
            // Move to order spot
            transform.position = Vector3.MoveTowards(
                transform.position,
                orderSpot.position,
                moveSpeed * Time.deltaTime
            );

            // Check if reached
            if (Vector3.Distance(transform.position, orderSpot.position) < 0.5f)
            {
                orderTaken = true;
                Debug.Log("One pepperoni pizza, please!");
            }
        }
        else if (hasPizza)
        {
            // Move to exit
            transform.position = Vector3.MoveTowards(
                transform.position,
                exitSpot.position,
                moveSpeed * Time.deltaTime
            );

            // Destroy at exit
            if (Vector3.Distance(transform.position, exitSpot.position) < 0.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void TakePizza()
    {
        if (!orderTaken) return;
        hasPizza = true;
        Debug.Log("Thank you!");
    }
}