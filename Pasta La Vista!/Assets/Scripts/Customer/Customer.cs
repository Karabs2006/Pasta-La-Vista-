using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour
{
    [Header("Customer Destinations")]
        public Transform orderSpot;
        public Transform exitSpot;

    [Header("Scripts")]
        public Interact interact;
        public Review review;
        public Order orderScript;
        public FPController fPController;
        public Animator animator;

    [Header("Game Objects")]
    public GameObject customer;
    public GameObject collectCollider;
    public GameObject boxCustomer;

    [Header("Audio")]
        AudioSource audioSource;
        AudioClip audioClip;
        public AudioSource angryCustomer;
        public AudioSource maleOrder;
        public AudioSource femaleOrder;
        public AudioClip angrySound;
        public AudioClip male;
        public AudioClip female;

    //Variables
        float moveSpeed = 2f;
        private bool orderTaken = false;
        private bool customerLeaving = false;
        bool inLine;

    void Start()
    {
        orderSpot = GameObject.FindWithTag("Order Spot").transform;
        exitSpot = GameObject.FindWithTag("Exit Spot").transform;
        inLine = false;
        boxCustomer.SetActive(false);
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
                animator.SetBool("AtOrderSpot", true);
                orderTaken = true;
                inLine = true;
                orderScript.order.enabled = true;
                collectCollider.SetActive(true);
                StartCoroutine(Timer());
            }
        }

        // After pizza taken, start leaving
        if (orderTaken && interact.takenPizza && !customerLeaving)
        {   
            boxCustomer.SetActive(true);
            animator.SetBool("PizzaTaken", true);
            StartCoroutine(Leave(customer));
            review.reviewScore += 500;
            orderScript.order.enabled = false;
            customerLeaving = true;
        }
    }

    IEnumerator Leave(GameObject cust)
    {   
        
        customer.transform.Rotate(0f, 180f, 0f);
        animator.SetBool("AtOrderSpot", false);
        fPController.interactPressed = false; 
        interact.givePizza = false;
        orderScript.order.enabled = false;
        orderScript.timer.SetActive(false);
        collectCollider.SetActive(false);

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

        cust.SetActive(false);

        // Customer reached exit
        yield return new WaitForSeconds(2f);
        customer.transform.Rotate(0f, 180f, 0f);
        
        // Reset flags for next customer
        orderTaken = false;
        customerLeaving = false;
        interact.takenPizza = false;
        inLine = false;

        // Reactivate same customer instead of random
        customer.SetActive(true);
        boxCustomer.SetActive(false);
        orderScript.GenerateOrder();
    }

    IEnumerator Timer()
    {
        orderScript.timer.SetActive(true);

        while (orderScript.time > 0)
        {
            orderScript.time--;
            orderScript.timerSeconds.text = "" + orderScript.time;

            if (orderScript.time <= 10)
            {
                orderScript.timerSeconds.color = Color.red;
            }
            yield return new WaitForSeconds(1f);
        }

        if (orderScript.time == 0 && !interact.takenPizza && !customerLeaving) // only leave if no pizza was given
        {   
            StopTimer();
            StartCoroutine(Leave(customer));
            animator.SetBool("NotDelivered", true);
            review.reviewScore -= 500;
            angryCustomer.PlayOneShot(angrySound);
            interact.givePizza = false;
        }
    }

    public void StopTimer()
    {   
        StopCoroutine(Timer());
        orderScript.timer.SetActive(false);
        fPController.interactPressed = false;
    }
}

