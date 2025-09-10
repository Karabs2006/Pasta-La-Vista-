using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Transform orderSpot;
    public Transform exitSpot;
    public Interact interact;
    public Review review;
    public Order orderScript;
    public float moveSpeed = 2f;
    private List<GameObject> customers;
    private GameObject customer;  // current active customer
    private bool orderTaken = false;
    private bool customerLeaving = false;
    bool inLine;
    bool timesUp = false;

    void Start()
    {
        customers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Customer"));
        orderSpot = GameObject.FindWithTag("Order Spot").transform;
        exitSpot = GameObject.FindWithTag("Exit Spot").transform;
        inLine = false;

        foreach (GameObject cust in customers)
        {
            if (cust != customer)
                cust.SetActive(false);
        }
        ;

        // Pick the first customer and deactivate the others
        PickRandomCustomer();
       

    }


    void Update()
    {
        if (customer == null) return;

        // Customer walking to order spot
        if (!orderTaken && !customerLeaving && !inLine)
        {
            customer.transform.position = Vector3.MoveTowards(
                customer.transform.position,
                orderSpot.position,
                moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(customer.transform.position, orderSpot.position) < 0.5f)
            {
                orderTaken = true;
                inLine = true;
                orderScript.order.enabled = true;
                StartCoroutine(Timer());
            }
        }

        // After pizza taken, start leaving
        if (orderTaken && interact.takenPizza && !customerLeaving)
        {
            review.reviewScore += 500;
            orderScript.order.enabled = false;
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

    IEnumerator Leave(GameObject cust)
    {   
        orderScript.order.enabled = false;
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
        inLine = false;

        // Pick next random customer
        PickRandomCustomer();

    }

    IEnumerator Angry(GameObject obj)
    {
        yield return new WaitForSeconds(1f); 
        review.reviewScore -= 500;

    }


    IEnumerator Timer()
    {
       yield return new WaitForSeconds(10f);

        if (!interact.takenPizza && !customerLeaving) // only leave if no pizza was given
        {   
            orderScript.reset = true;
            StartCoroutine(Leave(customer));
            review.reviewScore -= 500;
            print("You suck!");
        }
    }

}
