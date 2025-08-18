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
    public Gamepad gamepad;
    public Interact interact;
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
        
        gamepad = Gamepad.current;

        bool interactPressed = Input.GetKeyDown(KeyCode.E) || (gamepad != null && gamepad.buttonWest.wasPressedThisFrame);


        if (interactPressed)
        {
            if (interact.dough.activeSelf)
            {
                crust.SetActive(true);
                interact.dough.SetActive(false);
                crustPlaced = true;
                buildPizza = false;

            }


            if (interact.cheese.activeSelf)
            {
                cheese.SetActive(true);
                interact.cheese.SetActive(false);
                cheesePlaced = true;
                buildPizza = false;
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
