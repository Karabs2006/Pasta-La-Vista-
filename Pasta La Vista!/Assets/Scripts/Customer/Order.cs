using UnityEngine;
using TMPro;
using System.Collections;

public class Order : MonoBehaviour
{
    public TMP_Text order;
    public TMP_Text timer;
    public int numPizza;
    public bool reset = false;
    public int time;
    const int seconds = 20;

    void Start()
    {
        order.enabled = false;
        numPizza = Random.Range(1, 4);
        order.text = "Could I get " + numPizza + " pizzas please!";
        timer.enabled = false;
        time = seconds * numPizza;
    }

    void Update()
    {
        if (reset)
        {
        //StartCoroutine(Reset());
        }
    }


    /*IEnumerator Reset()
    {
        numPizza = Random.Range(1, 4);
        yield return new WaitForSeconds(1f);
        order.text = "Could I get " + numPizza + " pizzas please!";
        reset = false;
        
    }*/
    public void GenerateOrder()
    {
        numPizza = Random.Range(1, 4);
        time = seconds * numPizza; // fresh time each customer
        order.text = "Could I get " + numPizza + " pizzas please!";
    }

}
