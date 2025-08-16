using System.Collections;
using System.Collections.Generic;
//using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Oven : MonoBehaviour
{
    public GameObject bakedPizza;
    public GameObject rawPizza;
    public GameObject bakedPizzaPlayer;
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
        if (nearOven && pizzaBuild.pizza.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pizzaBuild.pizza.SetActive(false);
                rawPizza.SetActive(true);
                nearOven = false;
                StartCoroutine(BakePizza(bakedPizza));
            }
        }


        if (pizzaBaked && nearOven && Input.GetKeyDown(KeyCode.E))
        {
            bakedPizzaPlayer.SetActive(true);
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

