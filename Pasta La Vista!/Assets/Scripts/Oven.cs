using System.Collections;
using System.Collections.Generic;
//using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Oven : MonoBehaviour
{
    public GameObject bakedPizza;
    public GameObject rawPizza;
    public GameObject bakedPizzaPlayer;
    public Gamepad gamepad;
    public PizzaBuild pizzaBuild;
    public Slider slider;
    bool isBaking = false;
    bool nearOven;
    bool pizzaBaked;

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
        gamepad = Gamepad.current;

        bool interactPressed = Input.GetKeyDown(KeyCode.E) || (gamepad != null && gamepad.buttonWest.wasPressedThisFrame);


        if (nearOven && pizzaBuild.pizza.activeSelf)
        {
            if (interactPressed)
            {
                pizzaBuild.pizza.SetActive(false);
                rawPizza.SetActive(true);
                nearOven = false;
                StartCoroutine(BakePizza(bakedPizza));
            }
        }


        if (pizzaBaked && nearOven && interactPressed)
        {
            bakedPizzaPlayer.SetActive(true);
            bakedPizza.SetActive(false);
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
        isBaking = true;
        for (int i = 5; i >= 0; i--)
        {
            slider.value = i;
            yield return new WaitForSeconds(1f);
        }

        obj.SetActive(true);
        rawPizza.SetActive(false);
        isBaking = false;
        pizzaBaked = true;



    }



}

