using UnityEngine;

public class DustbinTutorial : MonoBehaviour
{
    public OvenTutorial oven;
    public FPController fPController;
    public PizzaBuildTutorial pizzaBuild;
    bool nearBin = false;

    void Update()
    {
        if (nearBin && fPController.interactPressed && oven.bakedPizzaPlayer.activeSelf)
        {
            oven.bakedPizzaPlayer.SetActive(false);
            fPController.interactPressed = false;
        }

        else if (nearBin && fPController.interactPressed && oven.bakedCheesePlayer.activeSelf)
        {
            oven.bakedCheesePlayer.SetActive(false);
            fPController.interactPressed = false;
            oven.cheesePizzaActive = false;
        }

        else if (nearBin && fPController.interactPressed && pizzaBuild.pizza.activeSelf)
        {
            pizzaBuild.pizza.SetActive(false);
            fPController.interactPressed = false;
        }

        else if (nearBin && fPController.interactPressed && pizzaBuild.cheesePizza.activeSelf)
        {
            pizzaBuild.cheesePizza.SetActive(false);
            fPController.interactPressed = false;
            
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
}
