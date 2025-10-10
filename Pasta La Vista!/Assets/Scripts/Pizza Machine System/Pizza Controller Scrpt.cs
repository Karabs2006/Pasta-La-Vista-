using UnityEngine;

public class PizzaController : MonoBehaviour
{
    // Assign these in Inspector - all child objects of the pizza
    public GameObject doughLayer;
    public GameObject sauceLayer;
    public GameObject cheeseLayer;
    public GameObject pepperoniLayer;
    public GameObject bakedPizzaLayer;
    public GameObject boxedPizzaLayer;

    void Start()
    {
        // Make sure pizza has the correct tag
        gameObject.tag = "Pizza";

        // Start as pizza base (dough only)
        ResetToDough();
    }

    public void ResetToDough()
    {
        doughLayer.SetActive(true);
        sauceLayer.SetActive(false);
        cheeseLayer.SetActive(false);
        pepperoniLayer.SetActive(false);
        bakedPizzaLayer.SetActive(false);
        boxedPizzaLayer.SetActive(false);
    }

    public void AddSauce()
    {
        if (doughLayer.activeSelf) // Only if we have dough
        {
            sauceLayer.SetActive(true);
            Debug.Log("Sauce added to pizza!");
        }
    }

    public void AddCheese()
    {
        if (doughLayer.activeSelf && sauceLayer.activeSelf) // Only if we have dough and sauce
        {
            cheeseLayer.SetActive(true);
            Debug.Log("Cheese added to pizza!");
        }
    }

    public void AddPepperoni()
    {
        if (doughLayer.activeSelf && sauceLayer.activeSelf && cheeseLayer.activeSelf) // Only if complete so far
        {
            pepperoniLayer.SetActive(true);
            Debug.Log("Pepperoni added to pizza!");
        }
    }

    public void BakePizza()
    {
        if (doughLayer.activeSelf && sauceLayer.activeSelf && cheeseLayer.activeSelf && pepperoniLayer.activeSelf)
        {
            // Hide raw pizza, show baked version
            doughLayer.SetActive(false);
            sauceLayer.SetActive(false);
            cheeseLayer.SetActive(false);
            pepperoniLayer.SetActive(false);
            bakedPizzaLayer.SetActive(true);
            Debug.Log("Pizza baked!");
        }
    }

    public void BoxPizza()
    {
        if (bakedPizzaLayer.activeSelf) // Only if baked
        {
            bakedPizzaLayer.SetActive(false);
            boxedPizzaLayer.SetActive(true);
            Debug.Log("Pizza boxed!");
        }
    }
}