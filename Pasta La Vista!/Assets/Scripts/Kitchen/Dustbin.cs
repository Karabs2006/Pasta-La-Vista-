using UnityEngine;

public class Dustbin : MonoBehaviour
{
    public Oven oven;
    public FPController fPController;
    bool nearBin = false;

    void Update()
    {
        if(nearBin && fPController.interactPressed && oven.bakedPizzaPlayer.activeSelf)
        {
            oven.bakedPizzaPlayer.SetActive(false);
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
