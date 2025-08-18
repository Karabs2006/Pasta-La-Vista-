using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics.SymbolStore;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Interact : MonoBehaviour
{
    public GameObject cheese;
    public GameObject pepperoni;
    public GameObject dough;
    public GameObject customerPizza;
    private Gamepad gamepad;
    public GameObject customer;
    public Oven oven;
    bool cheeseZone;
    bool pepZone;
    bool doughZone;
    bool givePizza;
    public bool nextCustomer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cheese.SetActive(false);
        pepperoni.SetActive(false);
        dough.SetActive(false);
        customerPizza.SetActive(false);
        cheeseZone = false;
        pepZone = false;
        nextCustomer = false;

    }

    // Update is called once per frame
    void Update()
    {

        gamepad = Gamepad.current;

        bool interactPressed = Input.GetKeyDown(KeyCode.E) || (gamepad != null && gamepad.buttonWest.wasPressedThisFrame);


        if (interactPressed)
        {
            if (cheeseZone)
            {
                cheese.SetActive(true);
                pepperoni.SetActive(false);
                dough.SetActive(false);
            }

            if (pepZone)
            {
                pepperoni.SetActive(true);
                cheese.SetActive(false);
                dough.SetActive(false);

            }

            if (doughZone)
            {
                dough.SetActive(true);
                cheese.SetActive(false);
                pepperoni.SetActive(false);
            }

            if (givePizza && oven.bakedPizzaPlayer.activeSelf)
            {
                oven.bakedPizzaPlayer.SetActive(false);
                customerPizza.SetActive(true);
                Destroy(customer);
                customerPizza.SetActive(false);
                SceneManager.LoadSceneAsync("GameScene");
            }
        }

    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Cheese Collider")
        {
            cheeseZone = true;
        }

        if (trigger.gameObject.name == "Pepperoni Collider")
        {
            pepZone = true;
        }


        if (trigger.gameObject.name == "Dough Collider")
        {
            doughZone = true;
        }

        if (trigger.gameObject.name == "CollectSpot")
        {
            givePizza = true;
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cheese Collider")
        {
            cheeseZone = false;
        }

        if (other.gameObject.name == "Pepperoni Collider")
        {
            pepZone = false;
        }

        if (other.gameObject.name == "Dough Collider")
        {
            doughZone = false;
        }

        if (other.gameObject.name == "CollectSpot")
        {
            givePizza = false;
        }

    }

}
