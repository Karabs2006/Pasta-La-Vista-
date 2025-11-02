using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PizzaBuildTutorial : MonoBehaviour
{
    [Header ("Ingredients")]
        public GameObject crust;
        public GameObject cheese;
        public GameObject sauce;
        public GameObject pizza;
        public GameObject cheesePizza;
        

    [Header ("Scripts")]
        public InteractTutorial interact;
        public FPController fPController;
        public Tutorial tutorial;


    [Header("Booleans")]
        bool buildPizza;
        public bool ovenEmpty = true;
        public bool doughPlaced = false;
        public bool cheesePlaced = false;
        public bool saucePlaced = false;
        bool pepPlaced = false;
        bool pizzaEquiped = false;

    [Header("Audio")]
        public AudioSource audioSource;
        public AudioClip audioClip;
    
    void Start()
    {
        crust.SetActive(false);
        cheese.SetActive(false);
        sauce.SetActive(false);
        pizza.SetActive(false);
        cheesePizza.SetActive(false);
        
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
                audioSource.PlayOneShot(audioClip);
                buildPizza = false;
                fPController.interactPressed = false;
                doughPlaced = true;

            }

            if (interact.sauce.activeSelf && doughPlaced)
            {
                sauce.SetActive(true);
                interact.sauce.SetActive(false);
                audioSource.PlayOneShot(audioClip);
                buildPizza = false;
                fPController.interactPressed = false;
                saucePlaced = true;

            }


            if (interact.cheese.activeSelf && saucePlaced)
            {
                cheese.SetActive(true);
                interact.cheese.SetActive(false);
                audioSource.PlayOneShot(audioClip);
                buildPizza = false;
                fPController.interactPressed = false;
                cheesePlaced = true;

            }

            


            if (interact.pepperoni.activeSelf)
            {
                interact.pepperoni.SetActive(false);
                audioSource.PlayOneShot(audioClip);
                pepPlaced = true;
                buildPizza = false;


                if (cheesePlaced && doughPlaced && pepPlaced && saucePlaced)
                {   
                    pizzaEquiped = true;
                    pizza.SetActive(true);
                    crust.SetActive(false);
                    cheese.SetActive(false);
                    sauce.SetActive(false);
                    doughPlaced = false;
                    cheesePlaced = false;
                    pepPlaced = false;
                    saucePlaced = false;
                    fPController.interactPressed = false;

                    if(pizzaEquiped && !tutorial.buildTutorial)
                    {   
                        StartCoroutine(LoadDelay());
                    }
                }

            }

        }

        // CHEESE PIZZA
        if (cheesePlaced && doughPlaced && saucePlaced && fPController.interactPressed)
        {
            pizzaEquiped = true;
            cheesePizza.SetActive(true);
            fPController.interactPressed = false;
            crust.SetActive(false);
            cheese.SetActive(false);
            sauce.SetActive(false);

            if(pizzaEquiped && !tutorial.buildTutorial)
            {   
                StartCoroutine(LoadDelay());  
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

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Pause();
        tutorial.baking.SetActive(true);
    }

    void Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fPController.lookSensitivity = 0f;
    }
}
