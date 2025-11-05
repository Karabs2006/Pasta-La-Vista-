using UnityEngine;

public class PlaceholderTwo : MonoBehaviour
{
    [Header("Game Objects")]
        public GameObject cheesePizzaOne;
        public GameObject cheesePizzaTwo;
        public GameObject pepPizzaOne;
        public GameObject pepPizzaTwo;
        
    [Header("Scripts")]
        public Oven oven;
        public FPController fPController;
        public Placeholder placeholder;
    
    [Header("Booleans")]
        public bool inZoneTwo = false;

    void Start()
    {
        cheesePizzaOne.SetActive(false);
        cheesePizzaTwo.SetActive(false);
        pepPizzaOne.SetActive(false);
        pepPizzaTwo.SetActive(false);
    }


    void Update()
    {
        if(fPController.interactPressed)
        {
            //---Zero Pizzas on Table---

            if (placeholder.inZoneOne && placeholder.pizzaCount == 0 && oven.bakedCheesePlayer.activeSelf)
                {
                    placeholder.PlacePizza(cheesePizzaOne, oven.bakedCheesePlayer);
                }

            if (inZoneTwo && placeholder.pizzaCount == 0 && oven.bakedCheesePlayer.activeSelf)
                {
                    placeholder.PlacePizza(cheesePizzaTwo, oven.bakedCheesePlayer);
                }

            if (placeholder.inZoneOne && placeholder.pizzaCount == 0 && oven.bakedPizzaPlayer.activeSelf)
                {
                    placeholder.PlacePizza(pepPizzaOne, oven.bakedPizzaPlayer);
                }

            if (inZoneTwo && placeholder.pizzaCount == 0 && oven.bakedPizzaPlayer.activeSelf)
                {
                    placeholder.PlacePizza(pepPizzaTwo, oven.bakedPizzaPlayer);
                }

            //---One Pizza on Table---

            if (placeholder.inZoneOne && placeholder.pizzaCount == 1 && oven.bakedCheesePlayer.activeSelf && (cheesePizzaTwo.activeSelf || pepPizzaTwo.activeSelf))
                {
                    placeholder.PlacePizza(cheesePizzaOne, oven.bakedCheesePlayer);
                }

            if (inZoneTwo && placeholder.pizzaCount == 1 && oven.bakedCheesePlayer.activeSelf && (cheesePizzaOne.activeSelf || pepPizzaOne.activeSelf))
                {
                    placeholder.PlacePizza(cheesePizzaTwo, oven.bakedCheesePlayer);
                }

            if (placeholder.inZoneOne && placeholder.pizzaCount == 1 && oven.bakedPizzaPlayer.activeSelf && (cheesePizzaTwo.activeSelf || pepPizzaTwo.activeSelf) )
                {
                    placeholder.PlacePizza(pepPizzaOne, oven.bakedPizzaPlayer);
                }

            if (inZoneTwo && placeholder.pizzaCount == 1 && oven.bakedPizzaPlayer.activeSelf && (cheesePizzaOne.activeSelf || pepPizzaOne.activeSelf))
                {
                    placeholder.PlacePizza(pepPizzaTwo, oven.bakedPizzaPlayer);
                }

            //---The same Pizzas on Table---

            if (placeholder.inZoneOne && placeholder.pizzaCount == 1 && oven.bakedCheesePlayer.activeSelf && cheesePizzaTwo.activeSelf)
                {
                    placeholder.PlacePizza(cheesePizzaOne, oven.bakedCheesePlayer);
                }

            if (inZoneTwo && placeholder.pizzaCount == 1 && oven.bakedCheesePlayer.activeSelf && cheesePizzaOne.activeSelf)
                {
                    placeholder.PlacePizza(cheesePizzaTwo, oven.bakedCheesePlayer);
                }

            if (placeholder.inZoneOne && placeholder.pizzaCount == 1 && oven.bakedPizzaPlayer.activeSelf && pepPizzaTwo.activeSelf)
                {
                    placeholder.PlacePizza(pepPizzaOne, oven.bakedPizzaPlayer);
                }

            if (inZoneTwo && placeholder.pizzaCount == 1 && oven.bakedPizzaPlayer.activeSelf && pepPizzaOne.activeSelf)
                {
                    placeholder.PlacePizza(pepPizzaTwo, oven.bakedPizzaPlayer);
                }
        }

    }

    void OnTriggerEnter(Collider trigger)
    {   
        if (trigger.gameObject.name == "Player_Francesco")
        {
            inZoneTwo = true;
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            inZoneTwo = false;
        }
    }

}
