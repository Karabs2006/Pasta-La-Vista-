using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Oven : MonoBehaviour
{   
    [Header("Pizzas")]
        public GameObject bakedPizza;
        public GameObject rawPizza;
        public GameObject bakedPizzaPlayer;

    [Header("Scripts")]
        public FPController fPController;
        public PizzaBuild pizzaBuild;
        public Interact interact;
        public Slider slider;

    bool nearOven;
    bool pizzaBaked;
    public ParticleSystem steam;

    void Start()
    {
        rawPizza.SetActive(false);
        bakedPizza.SetActive(false);
        bakedPizzaPlayer.SetActive(false);
        nearOven = false;
        slider.value = 5;

    }
    void Update()
    {
        
        if (nearOven && pizzaBuild.pizza.activeSelf)
        {
            if (fPController.interactPressed)
            {
                pizzaBuild.pizza.SetActive(false);
                rawPizza.SetActive(true);
                nearOven = false;
                pizzaBuild.ovenEmpty = false;
                StartCoroutine(BakePizza(bakedPizza));
                fPController.interactPressed = false;
            }
        }


        if (pizzaBaked && nearOven && fPController.interactPressed && !pizzaBuild.ovenEmpty)
        {
            bakedPizzaPlayer.SetActive(true);
            bakedPizza.SetActive(false);
            interact.cheese.SetActive(false);
            interact.pepperoni.SetActive(false);
            interact.dough.SetActive(false);

            slider.value = 5;
            fPController.interactPressed = false;
            pizzaBuild.ovenEmpty = true;
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
        rawPizza.SetActive(false);
        pizzaBaked = true;
        
    }



}

