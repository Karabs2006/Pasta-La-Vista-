using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Oven : MonoBehaviour
{
    [Header("Classic Pepperoni Pizza")]
        public GameObject bakedPizza;
        public GameObject bakedPizzaPlayer;
        public GameObject rawPizza;

    [Header("Plain Cheese Pizza")]
        public GameObject rawCheesePizza;
        public GameObject bakedCheesePizza;
        public GameObject bakedCheesePlayer;
        
    [Header("Scripts")]
        public FPController fPController;
        public PizzaBuild pizzaBuild;
        public Interact interact;
        public Slider slider;
        public Order order;

        bool nearOven;
        bool pizzaBaked;
        bool cheesePizzaBaked;
        public ParticleSystem steam;

    void Start()
    {
        rawPizza.SetActive(false);
        bakedPizza.SetActive(false);
        bakedPizzaPlayer.SetActive(false);

        rawCheesePizza.SetActive(false);
        bakedCheesePizza.SetActive(false);
        bakedCheesePlayer.SetActive(false);

        nearOven = false;
        slider.value = 5;

    }
    void Update()
    {
        // CLASSIC PEPPERONI
        if (nearOven && pizzaBuild.pizza.activeSelf)
        {
            if (fPController.interactPressed)
            {   
                rawPizza.SetActive(true);
                pizzaBuild.pizza.SetActive(false);
                rawCheesePizza.SetActive(false);
                bakedCheesePizza.SetActive(false);

                nearOven = false;
                pizzaBuild.ovenEmpty = false;
                StartCoroutine(BakePizza(bakedPizza));
                fPController.interactPressed = false;
            }
        }

        if (pizzaBaked && nearOven && fPController.interactPressed && !pizzaBuild.ovenEmpty)
        {   
            order.isPepPizzaHeld = true;
            bakedPizzaPlayer.SetActive(true);
            bakedPizza.SetActive(false);

            bakedCheesePlayer.SetActive(false);
            bakedCheesePizza.SetActive(false);
            rawCheesePizza.SetActive(false);

            interact.cheese.SetActive(false);
            interact.pepperoni.SetActive(false);
            interact.dough.SetActive(false);

            slider.value = 5;
            fPController.interactPressed = false;
            pizzaBuild.ovenEmpty = true;

            pizzaBaked = false;
            cheesePizzaBaked = false;
        }

        // PLAIN CHEESE

        else if (nearOven && pizzaBuild.cheesePizza.activeSelf)
        {
            if (fPController.interactPressed)
            {   
                rawCheesePizza.SetActive(true);
                pizzaBuild.cheesePizza.SetActive(false);
                rawPizza.SetActive(false);
                bakedPizza.SetActive(false);

                nearOven = false;
                pizzaBuild.ovenEmpty = false;
                StartCoroutine(BakePizza(bakedCheesePizza));
                fPController.interactPressed = false;

                pizzaBuild.doughPlaced = false;
                pizzaBuild.cheesePlaced = false;
            }
        }

        if (cheesePizzaBaked && nearOven && fPController.interactPressed && !pizzaBuild.ovenEmpty)
        {
            order.isCheesePizzaHeld = true;
            bakedCheesePlayer.SetActive(true);
            bakedCheesePizza.SetActive(false);

            bakedPizzaPlayer.SetActive(false);
            bakedPizza.SetActive(false);
            rawPizza.SetActive(false);

            interact.cheese.SetActive(false);
            interact.pepperoni.SetActive(false);
            interact.dough.SetActive(false);

            slider.value = 5;
            fPController.interactPressed = false;
            pizzaBuild.ovenEmpty = true;

            pizzaBaked = false;
            cheesePizzaBaked = false;
        }

    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            nearOven = true;
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            nearOven = false;
        }
    }


    IEnumerator BakePizza(GameObject obj)
    {
        for (int i = 5; i >= 0; i--)
        {
            steam.Play();
            slider.value = i;
            yield return new WaitForSeconds(1f);
        }

        steam.Stop();
        obj.SetActive(true);

        if (obj == bakedPizza)
        {
            rawPizza.SetActive(false);
            pizzaBaked = true;
        }
        
        if(obj == bakedCheesePizza)
        {
            rawCheesePizza.SetActive(false); 
            cheesePizzaBaked = true;
        }
        
        
    }



}

