using System.Collections;
using UnityEngine;

public class Recipes : MonoBehaviour
{
    public FPController fPController;
    bool recipeActive = false;
    bool playerInTrigger = false;
    public GameObject recipes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        recipes.SetActive(false);
    }

    // Update is called once per frame
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
        fPController.lookSensitivity = 2f;

    }
    
    IEnumerator trigger()
    {
        yield return new WaitForSeconds(1f);
    }
}
