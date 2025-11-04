using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("Materials")]
        public Material pink;
        public Material blue;
        public Material brown;
        public Material green;

    [Header("Game Objects")]
        private GameObject customer;
        public GameObject custMaterial;

    [Header("Audio")]
        AudioSource audioSource;
        AudioClip audioClip;
        public AudioSource angryCustomer;
        public AudioSource maleOrder;
        public AudioSource femaleOrder;
        public AudioClip angrySound;
        public AudioClip male;
        public AudioClip female;
        
    
    //Lists
        private List<GameObject> customers;
        private List<Material> materials;

    //Variables
        float moveSpeed = 2f;
        private bool orderTaken = false;
        private bool customerLeaving = false;
        bool inLine;
        new Renderer renderer;

    void Start()
    {
        customers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Customer"));
        materials = new List<Material>
        {
            pink,
            blue,
            brown,
            green
        };

        renderer = custMaterial.GetComponent<Renderer>();
        renderer.material = brown;
        
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
                animator.SetBool("AtOrderSpot", true);
                orderTaken = true;
                inLine = true;
                orderScript.order.enabled = true;
                StartCoroutine(Timer());

                if (renderer.material == pink || brown)
                {
                    audioSource = femaleOrder;
                    audioClip = female;
                    audioSource.PlayOneShot(audioClip);
                }
                
                else if (renderer.material == blue || green)
                {
                    audioSource = maleOrder;
                    audioClip = male;
                    audioSource.PlayOneShot(audioClip);
                }
            }
        }

        // After pizza taken, start leaving
        if (orderTaken && interact.takenPizza && !customerLeaving)
        {   
            StartCoroutine(Leave(customer));
            review.reviewScore += 500;
            orderScript.order.enabled = false;
            customerLeaving = true;
        }
    }

    void PickRandomCustomer()
    {
        int rand = Random.Range(0, customers.Count);
        int mat = Random.Range(0, materials.Count);
        customer = customers[rand];
        renderer.material = materials[mat];
        customer.SetActive(true);

    }

    IEnumerator Leave(GameObject cust)
    {  
        customer.transform.Rotate(0f, 180f, 0f);
        animator.SetBool("AtOrderSpot", false);
        fPController.interactPressed = false; 
        interact.givePizza = false;
        orderScript.order.enabled = false;
        orderScript.timer.SetActive(false);

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

        // Pick next random customer
        PickRandomCustomer();
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
