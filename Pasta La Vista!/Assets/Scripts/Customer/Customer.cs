using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public GameObject orderCheesePizza;
    public GameObject orderPepPizza;

    [Header("Audio")]
        public AudioSource angryCustomer;
        public AudioSource orderSound;
        public AudioClip angrySound;
       

    //Variables
        float moveSpeed = 2f;
        private bool orderTaken = false;
        private bool customerLeaving = false;
        bool inLine;
    private List<GameObject> customers;
    private List<GameObject> boxes;
    private List<Animator> animators;


    [Header("Customers")]
        public GameObject cj;
        public GameObject franklin;
        public GameObject trevor;
        public GameObject micheal;

    [Header("Customer Boxes")]
        public GameObject cjBox;
        public GameObject frankBox;
        public GameObject trevBox;
        public GameObject mikeBox;


    [Header("Animators")]
        public Animator cjAnimator;
        public Animator franklinAnimator;
        public Animator trevorAnimator;
        public Animator mikeAnimator;
        
    void Start()
    {
        orderSpot = GameObject.FindWithTag("Order Spot").transform;
        exitSpot = GameObject.FindWithTag("Exit Spot").transform;
        inLine = false;
        boxCustomer.SetActive(false);
        orderCheesePizza.SetActive(false);
        orderPepPizza.SetActive(false);

        customers = new List<GameObject> { cj, franklin, trevor, micheal };
        boxes = new List<GameObject> { cjBox, frankBox, trevBox, mikeBox };
        animators = new List<Animator> { cjAnimator, franklinAnimator, trevorAnimator, mikeAnimator };

        foreach (var cust in customers)
        {
            cust.SetActive(false);
        }

        foreach (var box in boxes)
        {
            box.SetActive(false);
        }

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
                animator.SetBool("AtOrderSpot", true);
                orderTaken = true;
                inLine = true;
                orderScript.order.enabled = true;
                orderSound.Play();

                if (orderScript.pizzaType == 0)
                {
                    orderCheesePizza.SetActive(true);
                }

                
                if (orderScript.pizzaType == 1)
                {
                    orderPepPizza.SetActive(true);
                }
                
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
        cust.transform.Rotate(0f, 180f, 0f);
        animator.SetBool("AtOrderSpot", false);

        fPController.interactPressed = false; 
        interact.givePizza = false;
        orderScript.order.enabled = false;

        orderScript.timer.SetActive(false);
        collectCollider.SetActive(false);
        orderCheesePizza.SetActive(false);
        orderPepPizza.SetActive(false);
        boxCustomer.SetActive(false);

        // Move customer toward exit
        while (Vector3.Distance(cust.transform.position, exitSpot.position) > 0.5f)
        {
            cust.transform.position = Vector3.MoveTowards(
                cust.transform.position,
                exitSpot.position,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }

        cust.SetActive(false);

        // Reset flags
        orderTaken = false;
        customerLeaving = false;
        interact.takenPizza = false;
        inLine = false;

        // Pick next random customer
        PickRandomCustomer();
        cust.transform.Rotate(0f, 180f, 0f);
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

    void PickRandomCustomer()
    {
        
        int rand = Random.Range(0, customers.Count);

        if (customer != null) customer.SetActive(false);
        if (boxCustomer != null) boxCustomer.SetActive(false);

        customer = customers[rand];
        customer.SetActive(true);

        boxCustomer = boxes[rand];
        animator = animators[rand];

    }
     
}

