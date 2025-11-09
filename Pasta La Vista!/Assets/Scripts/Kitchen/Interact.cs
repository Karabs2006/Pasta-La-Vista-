using UnityEngine;

public class Interact : MonoBehaviour
{   
    [Header("Game Objects")]
        public GameObject cheese;
        public GameObject pepperoni;
        public GameObject dough;
        public GameObject sauce;
        public GameObject collectSpot;
        public GameObject pizzaBox;
        public GameObject pizzaBoxZone;
        public Animator animator;

    [Header("Scripts")]
        public FPController fPController;
        public Oven oven;
        public Order order;

    [Header("Booleans")]
        bool cheeseZone = false;
        bool pepZone = false;
        bool doughZone = false;
        bool sauceZone = false;
        bool inBoxZone = false;
        public bool givePizza = false;
        public bool takenPizza = false;
        public bool nextCustomer = false;
        public bool pepBox = false;
        public bool cheeseBox = false;
        int interactions = 0;

    [Header("Audio")]
        public AudioSource audioSource;
        public AudioSource boxingSound;
        public AudioClip audioClip;
        
    void Start()
    {
        cheese.SetActive(false);
        pepperoni.SetActive(false);
        dough.SetActive(false);
        sauce.SetActive(false);
        pizzaBox.SetActive(false);
    }

    void Update()
    {

        if (fPController.interactPressed)
        {
            if (!oven.pizzaEquipped)
            {
                if (cheeseZone && !oven.bakedPizzaPlayer.activeSelf && !oven.cheesePizzaActive)
                {
                    cheese.SetActive(true);
                    pepperoni.SetActive(false);
                    dough.SetActive(false);
                    sauce.SetActive(false);
                    fPController.interactPressed = false;
                    animator.SetBool("heldObject", true);

                }

                else if (pepZone && !oven.bakedPizzaPlayer.activeSelf && !oven.cheesePizzaActive)
                {
                    pepperoni.SetActive(true);
                    cheese.SetActive(false);
                    dough.SetActive(false);
                    sauce.SetActive(false);
                    fPController.interactPressed = false;
                    animator.SetBool("heldObject", true);
                }

                else if (doughZone && !oven.bakedPizzaPlayer.activeSelf && !oven.cheesePizzaActive)
                {
                    dough.SetActive(true);
                    cheese.SetActive(false);
                    pepperoni.SetActive(false);
                    sauce.SetActive(false);
                    fPController.interactPressed = false;
                    animator.SetBool("heldObject", true);
                }

                else if (sauceZone && !oven.bakedPizzaPlayer.activeSelf && !oven.cheesePizzaActive)
                {
                    sauce.SetActive(true);
                    dough.SetActive(false);
                    cheese.SetActive(false);
                    pepperoni.SetActive(false);
                    fPController.interactPressed = false;
                    animator.SetBool("heldObject", true);
                }
            }
            else
            {
                animator.SetBool("heldObject", false);
            }

            if (givePizza && pepBox)
            {
                if (order.pizzaType == 1)
                {
                    order.isPepPizzaHeld = false;
                    oven.pizzaEquipped = false;
                    oven.bakedPizzaPlayer.SetActive(false);
                    fPController.interactPressed = false;
                    pizzaBox.SetActive(false);
                    pepBox = false;
                    interactions++;

                    if (interactions == order.numPizza)
                    {
                        audioSource.PlayOneShot(audioClip);
                        takenPizza = true;
                        order.enabled = false;
                        interactions = 0;
                        animator.SetBool("heldObject", false);
                        pizzaBox.SetActive(false);
                    }

                }

            }

            if (givePizza && cheeseBox)
            {
                if (order.pizzaType == 0)
                {
                    oven.cheesePizzaActive = false;
                    oven.pizzaEquipped = false;
                    order.isCheesePizzaHeld = false;
                    oven.bakedCheesePlayer.SetActive(false);
                    fPController.interactPressed = false;
                    pizzaBox.SetActive(false);
                    cheeseBox = false;
                    interactions++;

                    if (interactions == order.numPizza)
                    {
                        audioSource.PlayOneShot(audioClip);
                        takenPizza = true;
                        order.enabled = false;
                        interactions = 0;
                        animator.SetBool("heldObject", false);
                    }
                }
            }
            
            if(inBoxZone)
            {
                if (oven.bakedPizzaPlayer.activeSelf)
                {   
                    fPController.interactPressed = false;
                    pizzaBox.SetActive(true);
                    oven.bakedPizzaPlayer.SetActive(false);
                    pepBox = true;
                    boxingSound.Play();

                }

                if (oven.bakedCheesePlayer.activeSelf)
                {   
                    fPController.interactPressed = false;
                    pizzaBox.SetActive(true);
                    oven.bakedCheesePlayer.SetActive(false);
                    cheeseBox = true;
                    boxingSound.Play();
                }
            }
        }
        

        if(fPController.emptyHandPressed)
        {
            if (cheese.activeSelf)
            {
                cheese.SetActive(false);
                fPController.emptyHandPressed = false;
            }

            if (pepperoni.activeSelf)
            {
                pepperoni.SetActive(false);
                fPController.emptyHandPressed = false;
            }

            if (dough.activeSelf)
            {
                dough.SetActive(false);
                fPController.emptyHandPressed = false;
            }
            if(sauce.activeSelf)
            {
                sauce.SetActive(false);
                fPController.emptyHandPressed = false;
            }
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Cheese Collider")
        {
            cheeseZone = true;
        }

        if (trigger.gameObject.name == "Pepperoni Collider")
        {
            pepZone = true;
        }

        if (trigger.gameObject.name == "Dough Collider")
        {
            doughZone = true;
        }

        if (trigger.gameObject.name == "Sauce Collider")
        {
            sauceZone = true;
        }

        if (trigger.gameObject == collectSpot)
        {
            givePizza = true;
        }

        if (trigger.gameObject == pizzaBoxZone)
        {
            inBoxZone = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cheese Collider")
        {
            cheeseZone = false;
        }

        if (other.gameObject.name == "Pepperoni Collider")
        {
            pepZone = false;
        }

        if (other.gameObject.name == "Dough Collider")
        {
            doughZone = false;
        }

        if (other.gameObject.name == "Sauce Collider")
        {
            sauceZone = false;
        }

        if (other.gameObject == collectSpot)
        {
            givePizza = false;
        }

        if (other.gameObject == pizzaBoxZone)
        {
            inBoxZone = false;
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
