using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics.SymbolStore;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public GameObject cheese;
    public GameObject pepperoni;
    public GameObject dough;
    private Gamepad gamepad;
    bool cheeseZone;
    bool pepZone;
    bool doughZone;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cheese.SetActive(false);
        pepperoni.SetActive(false);
        dough.SetActive(false);
        cheeseZone = false;
        pepZone = false;
    
    }

    // Update is called once per frame
    void Update()
    {

        gamepad = Gamepad.current;

        bool interactPressed = Input.GetKeyDown(KeyCode.E) || (gamepad != null && gamepad.buttonWest.wasPressedThisFrame);


        if (interactPressed)
        {
            if (cheeseZone && Input.GetKeyDown(KeyCode.E))
            {
                cheese.SetActive(true);
                pepperoni.SetActive(false);
                dough.SetActive(false);
            }

            if (pepZone && Input.GetKeyDown(KeyCode.E))
            {
                pepperoni.SetActive(true);
                cheese.SetActive(false);
                dough.SetActive(false);

            }

            if (doughZone && Input.GetKeyDown(KeyCode.E))
            {
                dough.SetActive(true);
                cheese.SetActive(false);
                pepperoni.SetActive(false);
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
    }
}
