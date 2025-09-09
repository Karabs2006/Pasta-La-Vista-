using UnityEngine;
using TMPro;
using System.Collections;

public class Order : MonoBehaviour
{
    public TMP_Text order;

    public int numPizza;
    public bool reset = false;

    void Start()
    {
        order.enabled = false;
        numPizza = Random.Range(1, 7);
        order.text = "Could I get " + numPizza + " pizzas please!";
    
    }

    void Update()
    {
        if (reset)
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        numPizza = Random.Range(1, 7);
        //order.enabled = false;
        yield return new WaitForSeconds(1f);
        order.text = "Could I get " + numPizza + " pizzas please!";
        reset = false;
    }
}
