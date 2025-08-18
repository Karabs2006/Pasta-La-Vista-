using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PizzaBuild : MonoBehaviour
{
    public GameObject crust;
    public GameObject cheese;
    public GameObject pepperoni;
    public GameObject pizza;
    public Interact interact;
    public FPController fPController;
    bool buildPizza;
    bool crustPlaced;
    bool cheesePlaced;
    bool pepperoniPlaced;
    public bool hasPizza = false;
    

    void Start()
    {
        crust.SetActive(false);
        cheese.SetActive(false);
        pepperoni.SetActive(false);
        pizza.SetActive(false);

    }

    void Update()
    {
        if (!buildPizza) return;

        if (fPController.interactPressed)
        {
            if (interact.dough.activeSelf)
            {
                crust.SetActive(true);
                interact.dough.SetActive(false);
                crustPlaced = true;
                buildPizza = false;
                fPController.interactPressed = false;

            }


            if (interact.cheese.activeSelf)
            {
                cheese.SetActive(true);
                interact.cheese.SetActive(false);
                cheesePlaced = true;
                buildPizza = false;
                fPController.interactPressed = false;
            }


            if (interact.pepperoni.activeSelf)
            {
                pepperoni.SetActive(true);
                interact.pepperoni.SetActive(false);
                pepperoniPlaced = true;

                pizza.SetActive(true);
                crust.SetActive(false);
                cheese.SetActive(false);
                pepperoni.SetActive(false);

                buildPizza = false;
                fPController.interactPressed = false;
            }
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Pizza Collider")
        {
            buildPizza = true;
        }
    }
}
