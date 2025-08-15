using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PizzaBuild : MonoBehaviour
{
    public GameObject crust;
    public GameObject cheese;
    public GameObject pepperoni;
    public GameObject pizza;
    public Interact interact;
    bool buildPizza;
    bool crustPlaced;
    bool cheesePlaced;
    bool pepperoniPlaced;
    bool finalPizza;
    bool bakePizza;
   
    void Start()
    {
        crust.SetActive(false);
        cheese.SetActive(false);
        pepperoni.SetActive(false);
        pizza.SetActive(false);
    }

    void Update()
    {
        if (buildPizza)
        {
            if (interact.dough.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                crust.SetActive(true);
                interact.dough.SetActive(false);
                crustPlaced = true;
                buildPizza = false;
                finalPizza = false;
            }

            if (interact.cheese.activeSelf && Input.GetKeyDown(KeyCode.E) && crustPlaced)
            {
                cheese.SetActive(true);
                interact.cheese.SetActive(false);
                cheesePlaced = true;
                buildPizza = false;
                finalPizza = false;

            }

            if (interact.pepperoni.activeSelf && Input.GetKeyDown(KeyCode.E) && cheesePlaced)
            {
                pepperoni.SetActive(true);
                interact.pepperoni.SetActive(false);
                pepperoniPlaced = true;
                buildPizza = false;
                finalPizza = true;
            }

        }

        if (finalPizza && buildPizza)
            {
                bakePizza = true;
            }

        if (bakePizza && Input.GetKeyDown(KeyCode.E))
        {
            pizza.SetActive(true);
            crust.SetActive(false);
            cheese.SetActive(false);
            pepperoni.SetActive(false);
            bakePizza = false;
        
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
