using UnityEngine;

public class Placeholder : MonoBehaviour
{
    [Header("Game Objects")]
        public GameObject cheesePizzaOne;
        public GameObject cheesePizzaTwo;
        public GameObject pepPizzaOne;
        public GameObject pepPizzaTwo;
        
    [Header("Scripts")]
        public Oven oven;
        public FPController fPController;
        public PlaceholderTwo placeholderTwo;
        
    [Header("Booleans")]
        public bool inZoneOne = false;
        public int pizzaCount = 0;

    void Start()
    {
        cheesePizzaOne.SetActive(false);
        cheesePizzaTwo.SetActive(false);
        pepPizzaOne.SetActive(false);
        pepPizzaTwo.SetActive(false);

    }

    void Update()
    {
        if (fPController.interactPressed)
        {
            //---Zero Pizzas on Table---

            if (inZoneOne && pizzaCount == 0 && oven.bakedCheesePlayer.activeSelf)
            {
                PlacePizza(cheesePizzaOne, oven.bakedCheesePlayer);
            }

            if (placeholderTwo.inZoneTwo && pizzaCount == 0 && oven.bakedCheesePlayer.activeSelf)
            {
                PlacePizza(cheesePizzaTwo, oven.bakedCheesePlayer);
            }

            if (inZoneOne && pizzaCount == 0 && oven.bakedPizzaPlayer.activeSelf)
            {
                PlacePizza(pepPizzaOne, oven.bakedPizzaPlayer);
            }

            if (placeholderTwo.inZoneTwo && pizzaCount == 0 && oven.bakedPizzaPlayer.activeSelf)
            {
                PlacePizza(pepPizzaTwo, oven.bakedPizzaPlayer);
            }

            //---One Pizza on Table---

            if (inZoneOne && pizzaCount == 1 && oven.bakedCheesePlayer.activeSelf && (cheesePizzaTwo.activeSelf || pepPizzaTwo.activeSelf))
            {
                PlacePizza(cheesePizzaOne, oven.bakedCheesePlayer);
            }

            if (placeholderTwo.inZoneTwo && pizzaCount == 1 && oven.bakedCheesePlayer.activeSelf && (cheesePizzaOne.activeSelf || pepPizzaOne.activeSelf))
            {
                PlacePizza(cheesePizzaTwo, oven.bakedCheesePlayer);
            }

            if (inZoneOne && pizzaCount == 1 && oven.bakedPizzaPlayer.activeSelf && (cheesePizzaTwo.activeSelf || pepPizzaTwo.activeSelf))
            {
                PlacePizza(pepPizzaOne, oven.bakedPizzaPlayer);
            }

            if (placeholderTwo.inZoneTwo && pizzaCount == 1 && oven.bakedPizzaPlayer.activeSelf && (cheesePizzaOne.activeSelf || pepPizzaOne.activeSelf))
            {
                PlacePizza(pepPizzaTwo, oven.bakedPizzaPlayer);
            }

            //---The same Pizzas on Table---

            if (inZoneOne && pizzaCount == 1 && oven.bakedCheesePlayer.activeSelf && cheesePizzaTwo.activeSelf)
            {
                PlacePizza(cheesePizzaOne, oven.bakedCheesePlayer);
            }

            if (placeholderTwo.inZoneTwo && pizzaCount == 1 && oven.bakedCheesePlayer.activeSelf && cheesePizzaOne.activeSelf)
            {
                PlacePizza(cheesePizzaTwo, oven.bakedCheesePlayer);
            }

            if (inZoneOne && pizzaCount == 1 && oven.bakedPizzaPlayer.activeSelf && pepPizzaTwo.activeSelf)
            {
                PlacePizza(pepPizzaOne, oven.bakedPizzaPlayer);
            }

            if (placeholderTwo.inZoneTwo && pizzaCount == 1 && oven.bakedPizzaPlayer.activeSelf && pepPizzaOne.activeSelf)
            {
                PlacePizza(pepPizzaTwo, oven.bakedPizzaPlayer);
            }


            //---Pickup Pizzas from table
        
            if (inZoneOne && !oven.pizzaEquipped && cheesePizzaOne.activeSelf)
            {
                TakePizza(oven.bakedCheesePlayer, cheesePizzaOne);
            }

            if (inZoneOne && !oven.pizzaEquipped && pepPizzaOne.activeSelf)
            {
                TakePizza(oven.bakedPizzaPlayer, pepPizzaOne);
            }

            if (placeholderTwo.inZoneTwo && !oven.pizzaEquipped && cheesePizzaTwo.activeSelf)
            {
                TakePizza(oven.bakedCheesePlayer, cheesePizzaTwo);
            }

            if (placeholderTwo.inZoneTwo && !oven.pizzaEquipped && pepPizzaTwo.activeSelf)
            {
                TakePizza(oven.bakedPizzaPlayer, pepPizzaTwo);
            }
        }

    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            inZoneOne = true;
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            inZoneOne = false;
        }
    }

    public void PlacePizza(GameObject objOne, GameObject objTwo)
    {
        objOne.SetActive(true);
        objTwo.SetActive(false);
        pizzaCount++;
        fPController.interactPressed = false;
        oven.pizzaEquipped = false;

    }

    public void TakePizza(GameObject objectOne, GameObject objectTwo)
    {
        objectOne.SetActive(true);
        objectTwo.SetActive(false);
        pizzaCount--;
        fPController.interactPressed = false;
        oven.pizzaEquipped = true;
        
    }

}

