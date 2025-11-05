using UnityEngine;

public class Dustbin : MonoBehaviour
{
    public Oven oven;
    public FPController fPController;
    public PizzaBuild pizzaBuild;
    bool nearBin = false;

    void Update()
    {
        if (nearBin && fPController.interactPressed && oven.bakedPizzaPlayer.activeSelf)
        {
            Throw(oven.bakedPizzaPlayer);
        }

        else if (nearBin && fPController.interactPressed && oven.bakedCheesePlayer.activeSelf)
        {
            Throw(oven.bakedCheesePlayer);
        }

        else if (nearBin && fPController.interactPressed && pizzaBuild.pizza.activeSelf)
        {
            Throw(pizzaBuild.pizza);
        }

        else if (nearBin && fPController.interactPressed && pizzaBuild.cheesePizza.activeSelf)
        {
            Throw(pizzaBuild.cheesePizza);
        }
    
    }
    
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            nearBin = true;
        }
    }
    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            nearBin = false;
        }
    }

    void Throw(GameObject obj)
    {
        obj.SetActive(false);
        fPController.interactPressed = false;
        oven.pizzaEquipped = false;
    }
}
