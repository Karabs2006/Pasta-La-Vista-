using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PizzaBuild : MonoBehaviour
{
    [Header ("Ingredients")]
        public GameObject crust;
        public GameObject cheese;
        public GameObject pizza;
        public GameObject cheesePizza;
        //public GameObject pepPizza;

    [Header ("Scripts")]
        public Interact interact;
        public FPController fPController;
    //public Oven oven;

    [Header("Booleans")]
        bool buildPizza;
        public bool ovenEmpty = true;
        public bool doughPlaced = false;
        public bool cheesePlaced = false;
        bool pepPlaced = false;
   
    void Start()
    {
        crust.SetActive(false);
        cheese.SetActive(false); 
        pizza.SetActive(false);
        cheesePizza.SetActive(false);
        //pepPizza.SetActive(false);
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
                doughPlaced = true;

            }


            if (interact.cheese.activeSelf)
            {
                cheese.SetActive(true);
                interact.cheese.SetActive(false);
                buildPizza = false;
                fPController.interactPressed = false;
                cheesePlaced = true;

            }


            if (interact.pepperoni.activeSelf)
            {
                interact.pepperoni.SetActive(false);
                pepPlaced = true;
                buildPizza = false;

                /*
                if (ovenEmpty)
                {
                    pizza.SetActive(true);
                    crust.SetActive(false);
                    cheese.SetActive(false);
                    pepperoni.SetActive(false);

                    cheesePlaced = false;
                    doughPlaced = false;
                    buildPizza = false;
                    fPController.interactPressed = false;
                }
                */

                if (cheesePlaced && doughPlaced && pepPlaced)
                {
                    pizza.SetActive(true);
                    fPController.interactPressed = false;
                    crust.SetActive(false);
                    cheese.SetActive(false);
                    doughPlaced = false;
                    cheesePlaced = false;
                    pepPlaced = false;
                }

            }

        }

        // CHEESE PIZZA
        if (cheesePlaced && doughPlaced && fPController.interactPressed)
        {
            cheesePizza.SetActive(true);
            fPController.interactPressed = false;
            crust.SetActive(false);
            cheese.SetActive(false);
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
