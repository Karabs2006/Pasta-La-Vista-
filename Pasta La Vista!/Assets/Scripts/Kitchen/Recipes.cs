using UnityEngine;
using System.Collections;

public class Recipes : MonoBehaviour
{
    public FPController fPController;
    bool recipeActive = false;
    bool playerInTrigger = false;
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
            Time.timeScale = 0f;
            recipes.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fPController.lookSensitivity = 0f;
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
        fPController.interactPressed = false;
        recipeActive = false;
        Time.timeScale = 1f;
        recipes.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 0.6f;

    }
    
    IEnumerator trigger()
    {
        yield return new WaitForSeconds(1f);
    }
}
