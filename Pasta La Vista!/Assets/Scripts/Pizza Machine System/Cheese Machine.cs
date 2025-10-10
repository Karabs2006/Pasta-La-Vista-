using UnityEngine;

public class CheeseMachine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            PizzaController pizza = other.GetComponent<PizzaController>();
            if (pizza != null)
            {
                pizza.AddCheese();
            }
        }
    }
}