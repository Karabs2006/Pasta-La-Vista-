using UnityEngine;

public class OvenMachine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            PizzaController pizza = other.GetComponent<PizzaController>();
            if (pizza != null)
            {
                pizza.BakePizza();
            }
        }
    }
}