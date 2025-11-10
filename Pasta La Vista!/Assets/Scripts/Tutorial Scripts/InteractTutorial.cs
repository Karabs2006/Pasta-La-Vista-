using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractTutorial : MonoBehaviour
{
    [Header("Player Ingredients")]
        public GameObject cheese;
        public GameObject pepperoni;
        public GameObject dough;
        public GameObject sauce;
        public GameObject pizzaBox;
        public GameObject pizzaBoxZone;

    [Header("Scripts")]
        public FPController fPController;
        public OvenTutorial oven;
        public OrderTutorial order;
        public Tutorial tutorial;
        
    [Header("Booleans")]
        bool cheeseZone = false;
        bool pepZone = false;
        bool doughZone = false;
        bool sauceZone = false;
        bool firstOrder = false;
        bool inBoxZone = false;
        public bool givePizza = false;
        public bool takenPizza = false;
        public bool nextCustomer = false;
        public bool pepBox = false;
        public bool cheeseBox = false;
        int interactions = 0;

    [Header("Audio")]
        public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioSource boxingSound;
        
    void Start()
    {
        cheese.SetActive(false);
        pepperoni.SetActive(false);
        dough.SetActive(false);
        sauce.SetActive(false);
        pizzaBox.SetActive(false);
    }

    void Update()
    {
        if (fPController.interactPressed && tutorial.phaseTwo)
        {
            if (!oven.pizzaEquipped)
            {
                if (cheeseZone && !oven.bakedPizzaPlayer.activeSelf && !oven.cheesePizzaActive)
                {
                    cheese.SetActive(true);
                    pepperoni.SetActive(false);
                    dough.SetActive(false);
                    sauce.SetActive(false);
                    fPController.interactPressed = false;

                }

                else if (pepZone && !oven.bakedPizzaPlayer.activeSelf && !oven.cheesePizzaActive)
                {
                    pepperoni.SetActive(true);
                    cheese.SetActive(false);
                    dough.SetActive(false);
                    sauce.SetActive(false);
                    fPController.interactPressed = false;
                }

                else if (doughZone && !oven.bakedPizzaPlayer.activeSelf && !oven.cheesePizzaActive)
                {
                    dough.SetActive(true);
                    cheese.SetActive(false);
                    pepperoni.SetActive(false);
                    sauce.SetActive(false);
                    fPController.interactPressed = false;
                }

                else if (sauceZone && !oven.bakedPizzaPlayer.activeSelf && !oven.cheesePizzaActive)
                {
                    sauce.SetActive(true);
                    dough.SetActive(false);
                    cheese.SetActive(false);
                    pepperoni.SetActive(false);
                    fPController.interactPressed = false;
                }
            }


            if (givePizza && pepBox)
            {
                if (order.pizzaType == 1)
                {
                    order.isPepPizzaHeld = false;
                    oven.pizzaEquipped = false;
                    oven.bakedPizzaPlayer.SetActive(false);
                    fPController.interactPressed = false;
                    interactions++;
                    pizzaBox.SetActive(false);
                    pepBox = false;


                    if (interactions == order.numPizza)
                    {
                        audioSource.PlayOneShot(audioClip);
                        takenPizza = true;
                        order.enabled = false;
                        interactions = 0;
                        firstOrder = true;
                        pizzaBox.SetActive(false);

                        if (firstOrder && !tutorial.firstOrderTutorial)
                        {
                            StartCoroutine(LoadDelay());
                        }
                    }


                }

            }

            if (givePizza && cheeseBox)
            {
                if (order.pizzaType == 0)
                {
                    oven.cheesePizzaActive = false;
                    oven.pizzaEquipped = false;
                    order.isCheesePizzaHeld = false;
                    oven.bakedCheesePlayer.SetActive(false);
                    fPController.interactPressed = false;
                    interactions++;
                    pizzaBox.SetActive(false);
                    cheeseBox = false;

                    if (interactions == order.numPizza)
                    {
                        audioSource.PlayOneShot(audioClip);
                        takenPizza = true;
                        order.enabled = false;
                        interactions = 0;
                        firstOrder = true;
                        pizzaBox.SetActive(false);

                        if (firstOrder && !tutorial.firstOrderTutorial)
                        {
                            StartCoroutine(LoadDelay());
                        }

                    }


                }

            }




            if(inBoxZone)
            {
                if (oven.bakedPizzaPlayer.activeSelf)
                {   
                    fPController.interactPressed = false;
                    pizzaBox.SetActive(true);
                    oven.bakedPizzaPlayer.SetActive(false);
                    pepBox = true;
                    boxingSound.Play();

                }

                if (oven.bakedCheesePlayer.activeSelf)
                {   
                    fPController.interactPressed = false;
                    pizzaBox.SetActive(true);
                    oven.bakedCheesePlayer.SetActive(false);
                    cheeseBox = true;
                    boxingSound.Play();
                }
            }
        }
            

            if(fPController.emptyHandPressed)
        {
            if (cheese.activeSelf)
            {
                cheese.SetActive(false);
                fPController.emptyHandPressed = false;
            }

            if (pepperoni.activeSelf)
            {
                pepperoni.SetActive(false);
                fPController.emptyHandPressed = false;
            }

            if (dough.activeSelf)
            {
                dough.SetActive(false);
                fPController.emptyHandPressed = false;
            }
            if(sauce.activeSelf)
            {
                sauce.SetActive(false);
                fPController.emptyHandPressed = false;
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

        if (trigger.gameObject.name == "Sauce Collider")
        {
            sauceZone = true;
        }

        if (trigger.gameObject.name == "CollectSpot")
        {
            givePizza = true;
        }

        if (trigger.gameObject == pizzaBoxZone)
        {
            inBoxZone = true;
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

        if (other.gameObject.name == "Sauce Collider")
        {
            sauceZone = false;
        }

        if (other.gameObject.name == "CollectSpot")
        {
            givePizza = false;
        }

        if (other.gameObject == pizzaBoxZone)
        {
            inBoxZone = false;
        }



    }

    void Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fPController.lookSensitivity = 0f;
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(0.8f);
        Pause();
        tutorial.phone.SetActive(true);
        
    }

}
