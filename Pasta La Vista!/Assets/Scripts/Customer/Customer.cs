using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Transform orderSpot;
    public Transform exitSpot;
    public Interact interact;
    public float moveSpeed = 2f;
    private List<GameObject> customers;
    private GameObject customer;  // current active customer
    private bool orderTaken = false;
    private bool customerLeaving = false;

    private void Start()
    {

        customers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Customer"));
        orderSpot = GameObject.FindWithTag("Order Spot").transform;
        exitSpot = GameObject.FindWithTag("Exit Spot").transform;

        foreach (GameObject cust in customers)
        {
            if (cust != customer)
                cust.SetActive(false);
        };

        // Pick the first customer and deactivate the others
        PickRandomCustomer();

    }

    void Update()
    {
        if (customer == null) return;

        // Customer walking to order spot
        if (!orderTaken && !customerLeaving)
        {
            customer.transform.position = Vector3.MoveTowards(
                customer.transform.position,
                orderSpot.position,
                moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(customer.transform.position, orderSpot.position) < 0.5f)
            {
                orderTaken = true;
                Debug.Log("One pepperoni pizza, please!");
            }
        }

        // After pizza taken, start leaving
        if (orderTaken && interact.takenPizza && !customerLeaving)
        {
            customerLeaving = true;
            StartCoroutine(Leave(customer));
        }
    }

    void PickRandomCustomer()
    {
        int rand = Random.Range(0, customers.Count);
        customer = customers[rand];
        customer.SetActive(true);
    }

    /* void DeactivateOtherCustomers()
     {
         foreach (GameObject cust in customers)
         {
             if (cust != customer)
                 cust.SetActive(false);
         }
     }
     */

    IEnumerator Leave(GameObject cust)
    {
        // Move customer toward exit over time
        while (Vector3.Distance(cust.transform.position, exitSpot.position) > 0.5f)
        {
            cust.transform.position = Vector3.MoveTowards(
                cust.transform.position,
                exitSpot.position,
                moveSpeed * Time.deltaTime
            );
            yield return null; // wait 1 frame before next movement
        }

        // Customer reached exit
        yield return new WaitForSeconds(1f);
        cust.SetActive(false);

        // Reset flags for next customer
        orderTaken = false;
        customerLeaving = false;
        interact.takenPizza = false;


        // Deactivate all others
        foreach (GameObject person in customers)
        {
            if (person != customer)
                person.SetActive(false);
        }

        // Pick next random customer
        PickRandomCustomer();
        
    }

}
