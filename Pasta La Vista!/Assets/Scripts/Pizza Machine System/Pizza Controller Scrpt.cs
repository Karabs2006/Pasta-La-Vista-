using System.Collections;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    public GameObject doughLayer;
    public GameObject sauceLayer;
    public GameObject cheeseLayer;
    public GameObject pepperoniLayer;
    public GameObject bakedPizzaLayer;
    public GameObject boxedPizzaLayer;
    public bool pizzaActive = false;

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
            
        }
    }

    public void AddCheese()
    {
        if (doughLayer.activeSelf && sauceLayer.activeSelf) 
        {
            cheeseLayer.SetActive(true);
            
        }
    }

    public void AddPepperoni()
    {
        if (doughLayer.activeSelf && sauceLayer.activeSelf && cheeseLayer.activeSelf) 
        {
            pepperoniLayer.SetActive(true);
            
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
            
        }
    }

    public void BoxPizza()
    {
        if (bakedPizzaLayer.activeSelf)
        {
            bakedPizzaLayer.SetActive(false);
            boxedPizzaLayer.SetActive(true);
        }
    }
    
    IEnumerator NextPizza ()
    {
        yield return new WaitForSeconds(2f);
        Destroy(boxedPizzaLayer);

        
    }
}