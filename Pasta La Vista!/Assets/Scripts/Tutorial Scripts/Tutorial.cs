using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Tutorial : MonoBehaviour
{   
    [Header("Scripts")]
        public FPController fPController;
    
    [Header("Game Objects")]
        public GameObject intro;
        public GameObject movement;
        public GameObject customer;
        public GameObject recipes;
        public GameObject pizzaBuilding;
        public GameObject baking;
        public GameObject placeholder;
        public GameObject phone;
        public GameObject rivalReviews;
        public GameObject playerReviews;
        public GameObject outro;
        

    [Header("Booleans")]
        public bool pizzaBuild = false;
        public bool buildTutorial = false;
        public bool firstOrderTutorial = false;
        public bool firstPhonePickup = true;
        public bool phaseTwo = false;
        public bool phaseThree = false;

        public AudioSource buttonAudio;


    void Start()
    {
        intro.SetActive(true);
        Pause();

        movement.SetActive(false);
        customer.SetActive(false);
        recipes.SetActive(false);
        pizzaBuilding.SetActive(false);
        baking.SetActive(false);
        placeholder.SetActive(false);
        phone.SetActive(false);
        rivalReviews.SetActive(false);
        playerReviews.SetActive(false);
        outro.SetActive(false);
    }

    void Update()
    {
        if(phone.activeSelf)
        {
            phaseThree = true;
        }
    }

    public void LoadMovement()//Intro
    {
        intro.SetActive(false);
        movement.SetActive(true);
        PlaySound();
    }

    public void LoadCustomer()
    {
        movement.SetActive(false);
        StartCoroutine(TimedLoad(customer, 5));
        PlaySound();
    }

    public void CloseCustomer() //Put on Customer
    {
        customer.SetActive(false);
        StartCoroutine(TimedLoad(recipes, 3));
        PlaySound();
    }

    public void CloseRecipes()//Same Name
    {
        Resume();
        recipes.SetActive(false);
        PlaySound();
    }

    public void CloseBuilding()//Same Name
    {   
        Resume();
        pizzaBuild = true;
        pizzaBuilding.SetActive(false);
        PlaySound();
        
    }

    public void CloseBaking()//Same Name
    {
        placeholder.SetActive(true);
        buildTutorial = true;
        phaseTwo = true;
        baking.SetActive(false);
        PlaySound();
    }

    public void ClosePlaceholder()
    {
        Resume();
        placeholder.SetActive(false);
        PlaySound();
    }

    public void LoadReviews()
    {
        rivalReviews.SetActive(false);
        playerReviews.SetActive(true);
        PlaySound();
    }

    public void LoadOutro()
    {
        playerReviews.SetActive(false);
        outro.SetActive(true);
        PlaySound();
        
    }

    public void LoadingScreen()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    IEnumerator TimedLoad(GameObject obj, float i)
    {
        Resume();
        yield return new WaitForSeconds(i);
        Pause();
        obj.SetActive(true);
    }
    
    public void Pause()
    {   
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fPController.lookSensitivity = 0f;
    }

    void Resume()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 0.6f;
    }
    
    public void PlaySound()
    {
        buttonAudio.Play();
    }

}

