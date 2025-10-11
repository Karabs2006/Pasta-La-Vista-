using UnityEngine;

public class PizzaController : MonoBehaviour
{
    
    public GameObject doughLayer;
    public GameObject sauceLayer;
    public GameObject cheeseLayer;
    public GameObject pepperoniLayer;
    public GameObject bakedPizzaLayer;
    public GameObject boxedPizzaLayer;

    void Start()
    {
        
        gameObject.tag = "Pizza";

       
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
        if (doughLayer.activeSelf) 
        {
            sauceLayer.SetActive(true);
            Debug.Log("Sauce added to pizza!");
        }
    }

    public void AddCheese()
    {
        if (doughLayer.activeSelf && sauceLayer.activeSelf) 
        {
            cheeseLayer.SetActive(true);
            Debug.Log("Cheese added to pizza!");
        }
    }

    public void AddPepperoni()
    {
        if (doughLayer.activeSelf && sauceLayer.activeSelf && cheeseLayer.activeSelf) 
        {
            pepperoniLayer.SetActive(true);
            Debug.Log("Pepperoni added to pizza!");
        }
    }

    public void BakePizza()
    {
        if (doughLayer.activeSelf && sauceLayer.activeSelf && cheeseLayer.activeSelf && pepperoniLayer.activeSelf)
        {
            
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
        if (bakedPizzaLayer.activeSelf) 
        {
            bakedPizzaLayer.SetActive(false);
            boxedPizzaLayer.SetActive(true);
            Debug.Log("Pizza boxed!");
        }
    }
}