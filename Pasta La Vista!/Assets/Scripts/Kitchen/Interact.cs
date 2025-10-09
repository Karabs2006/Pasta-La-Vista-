using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{   
    [Header("Player Ingredients")]
        public GameObject cheese;
        public GameObject pepperoni;
        public GameObject dough;

    [Header("Scripts")]
        public FPController fPController;
        public Oven oven;
        public Order order;
        
    [Header("Booleans")]
        bool cheeseZone;
        bool pepZone;
        bool doughZone;
        bool givePizza;
        public bool takenPizza;
        public bool nextCustomer;
    int interactions = 0;

    void Start()
    {
        cheese.SetActive(false);
        pepperoni.SetActive(false);
        dough.SetActive(false);
        cheeseZone = false;
        pepZone = false;
        nextCustomer = false;
        takenPizza = false;
    }

    void Update()
    {

        if (fPController.interactPressed )
        {
            if (cheeseZone && !oven.bakedPizzaPlayer.activeSelf)
            {
                cheese.SetActive(true);
                pepperoni.SetActive(false);
                dough.SetActive(false);
                fPController.interactPressed = false;

            }

            if (pepZone && !oven.bakedPizzaPlayer.activeSelf)
            {
                pepperoni.SetActive(true);
                cheese.SetActive(false);
                dough.SetActive(false);
                fPController.interactPressed = false;
            }

            if (doughZone && !oven.bakedPizzaPlayer.activeSelf)
            {
                dough.SetActive(true);
                cheese.SetActive(false);
                pepperoni.SetActive(false);
                fPController.interactPressed = false;
            }

            if (givePizza && oven.bakedPizzaPlayer.activeSelf)
            {
                oven.bakedPizzaPlayer.SetActive(false);
                fPController.interactPressed = false;
                interactions++;

                if (interactions == order.numPizza)
                {
                    takenPizza = true;
                    order.enabled = false;
                    interactions = 0;
                    
                } 
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
