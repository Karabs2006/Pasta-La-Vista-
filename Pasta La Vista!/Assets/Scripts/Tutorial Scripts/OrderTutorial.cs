using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class OrderTutorial : MonoBehaviour
{
    public TMP_Text order;
    public TMP_Text timerSeconds;
    public GameObject timer;
    public int numPizza;
    public int time;
    public int pizzaType;
    const int seconds = 200;
    public List<string> pizzas;

    public bool isCheesePizzaHeld = false;
    public bool isPepPizzaHeld = false;

    void Start()
    {
        pizzas = new List<string>
        {   
            " Cheese Pizzas",
            " Classic Pepperoni"
        };

        order.enabled = false;
        numPizza = Random.Range(1, 2);
        pizzaType = Random.Range(0, pizzas.Count);
        order.text = "Could I get " + numPizza + pizzas[pizzaType];
        timer.SetActive(false);
        time = seconds * numPizza;
    }

    public void GenerateOrder()
    {
        numPizza = Random.Range(1, 2);
        pizzaType = Random.Range(0, pizzas.Count);
        time = seconds * numPizza; // fresh time each customer
        order.text = "Could I get " + numPizza + pizzas[pizzaType];
        timerSeconds.color = Color.white;
    }

}
