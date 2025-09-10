using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PizzaBuild : MonoBehaviour
{
    [Header ("Raw Ingredients")]
        public GameObject crust;
        public GameObject cheese;
        public GameObject pepperoni;
        public GameObject pizza;

    [Header ("Scripts")]
        public Interact interact;
        public FPController fPController;

    [Header ("Booleans")]
        bool buildPizza;
        public bool ovenEmpty = true;
    
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

        if (fPController.interactPressed && ovenEmpty)
        {
            if (interact.dough.activeSelf)
            {
                crust.SetActive(true);
                interact.dough.SetActive(false);
                buildPizza = false;
                fPController.interactPressed = false;

            }


            if (interact.cheese.activeSelf)
            {
                cheese.SetActive(true);
                interact.cheese.SetActive(false);
                buildPizza = false;
                fPController.interactPressed = false;
            }


            if (interact.pepperoni.activeSelf)
            {
                pepperoni.SetActive(true);
                interact.pepperoni.SetActive(false);

                if (ovenEmpty)
                {
                    pizza.SetActive(true);
                    crust.SetActive(false);
                    cheese.SetActive(false);
                    pepperoni.SetActive(false);

                    buildPizza = false;
                    fPController.interactPressed = false;
                }
               
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
