using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteveCustomers : MonoBehaviour
{
    [Header("Customer Destinations")]
    public Transform orderSpot;
    public Transform exitSpot;

    [Header("Scripts")]
    public Animator animator;

    [Header("Materials")]
    public Material pink;
    public Material blue;
    public Material brown;
    public Material green;

    [Header("Game Objects")]
    public GameObject customer;
    public GameObject custMaterial;
    public GameObject pizzaBox;

    private List<Material> materials;

    float moveSpeed = 2f;
    private bool orderTaken = false;
    private bool customerLeaving = false;
    new Renderer renderer;
    private Coroutine timerCoroutine;

    void Start()
    {
        materials = new List<Material> { pink, blue, brown, green };
        pizzaBox.SetActive(false);

        renderer = custMaterial.GetComponent<Renderer>();
        renderer.material = brown;

        orderSpot = GameObject.FindWithTag("Steve_Order Spot").transform;
        exitSpot = GameObject.FindWithTag("Steve_Exit Spot").transform;

        PickRandomCustomer();
    }

    void Update()
    {
        if (customer == null || customerLeaving) return;

        // Move customer to order spot
        customer.transform.position = Vector3.MoveTowards(
            customer.transform.position,
            orderSpot.position,
            moveSpeed * Time.deltaTime
        );

        if (!orderTaken && Vector3.Distance(customer.transform.position, orderSpot.position) < 0.5f)
        {
            orderTaken = true;
            animator.SetBool("AtOrderSpot", true);

            if (timerCoroutine == null)
                timerCoroutine = StartCoroutine(Timer());
        }
    }

    void PickRandomCustomer()
    {   
        animator.SetBool("TookPizza", false);
        pizzaBox.SetActive(false);
        int mat = Random.Range(0, materials.Count);
        renderer.material = materials[mat];
        customer.SetActive(true);

        orderTaken = false;
        customerLeaving = false;
        timerCoroutine = null;
    }

    IEnumerator Leave(GameObject cust)
    {
        pizzaBox.SetActive(true);
        customerLeaving = true;
        animator.SetBool("TookPizza", true);
        animator.SetBool("AtOrderSpot", false);
        cust.transform.Rotate(0f, 180f, 0f);

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
        yield return new WaitForSeconds(2f);

        cust.transform.Rotate(0f, 180f, 0f);
        PickRandomCustomer();
    }

    IEnumerator Timer(int time = 15)
    {
        while (time > 0)
        {
            time--;
            yield return new WaitForSeconds(1f);
        }

        StartCoroutine(Leave(customer));
        timerCoroutine = null;
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }
}
