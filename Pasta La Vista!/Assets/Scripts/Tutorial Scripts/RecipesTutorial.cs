using UnityEngine;
using System.Collections;

public class RecipesTutorial : MonoBehaviour
{
    public FPController fPController;
    public Tutorial tutorial;
    bool recipeActive = false;
    bool playerInTrigger = false;
    bool pressedOnce = false;
    public GameObject recipes;
    
    
    void Start()
    {
        recipes.SetActive(false);
    }

    void Update()
    {   
        if (playerInTrigger && fPController.interactPressed)
        {
            recipeActive = true;
        }

        if(recipeActive)
        {
            recipes.SetActive(true);
            Pause();
            tutorial.phaseTwo = true;
        }

    }
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            playerInTrigger = true;
        }
    }
    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.name == "Player_Francesco")
        {
            playerInTrigger = false;
        }
    }

    public void Resume()
    {
        recipes.SetActive(false);
        tutorial.PlaySound();

        fPController.interactPressed = false;
        recipeActive = false;
        
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 0.45f;
        pressedOnce = true;

        if (pressedOnce && !tutorial.pizzaBuild)
        {
            Pause();
            tutorial.pizzaBuilding.SetActive(true);
          
        }

    }

    void Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fPController.lookSensitivity = 0f;
    }

}
