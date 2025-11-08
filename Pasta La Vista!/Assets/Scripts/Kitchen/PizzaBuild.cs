using UnityEngine;

public class PizzaBuild : MonoBehaviour
{
    [Header ("Ingredients")]
        public GameObject crust;
        public GameObject cheese;
        public GameObject sauce;
        public GameObject pizza;
        public GameObject cheesePizza;
        

    [Header ("Scripts")]
        public Interact interact;
        public FPController fPController;
    public GameManager gameManager;
       
    [Header("Booleans")]
        bool buildPizza;
        public bool ovenEmpty = true;
        public bool doughPlaced = false;
        public bool cheesePlaced = false;
        public bool saucePlaced = false;
        bool pepPlaced = false;
        bool pizzaEquiped = false;

    [Header("Audio")]
        public AudioSource audioSource;
        public AudioClip audioClip;
    public Animator animator;
    
    void Start()
    {
        crust.SetActive(false);
        cheese.SetActive(false);
        sauce.SetActive(false);
        pizza.SetActive(false);
        cheesePizza.SetActive(false);
        
    }

    void Update()
    {
        if (!buildPizza) return;

        if (fPController.interactPressed && gameManager.count < 2 && gameManager.count >=0)
        {
            if (interact.dough.activeSelf)
            {
                crust.SetActive(true);
                interact.dough.SetActive(false);
                audioSource.PlayOneShot(audioClip);
                buildPizza = false;
                fPController.interactPressed = false;
                doughPlaced = true;
                animator.SetBool("heldObject", false);

            }

            if (interact.sauce.activeSelf && doughPlaced)
            {
                sauce.SetActive(true);
                interact.sauce.SetActive(false);
                audioSource.PlayOneShot(audioClip);
                buildPizza = false;
                fPController.interactPressed = false;
                saucePlaced = true;
                animator.SetBool("heldObject", false);

            }

            if (interact.cheese.activeSelf && saucePlaced)
            {
                cheese.SetActive(true);
                interact.cheese.SetActive(false);
                audioSource.PlayOneShot(audioClip);
                buildPizza = false;
                fPController.interactPressed = false;
                cheesePlaced = true;
                animator.SetBool("heldObject", false);

            }

            if (interact.pepperoni.activeSelf)
            {
                interact.pepperoni.SetActive(false);
                audioSource.PlayOneShot(audioClip);
                pepPlaced = true;
                buildPizza = false;

                if (cheesePlaced && doughPlaced && pepPlaced && saucePlaced)
                {   
                    pizzaEquiped = true;
                    pizza.SetActive(true);
                    crust.SetActive(false);
                    cheese.SetActive(false);
                    sauce.SetActive(false);
                    doughPlaced = false;
                    cheesePlaced = false;
                    pepPlaced = false;
                    saucePlaced = false;
                    fPController.interactPressed = false;
                    animator.SetBool("heldObject", true);
                }
            }
        }

        // CHEESE PIZZA
        if (cheesePlaced && doughPlaced && saucePlaced && fPController.interactPressed)
        {
            pizzaEquiped = true;
            cheesePizza.SetActive(true);
            fPController.interactPressed = false;
            crust.SetActive(false);
            cheese.SetActive(false);
            sauce.SetActive(false);
            animator.SetBool("heldObject", true);
        }
  
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.name == "Pizza Collider")
        {
            buildPizza = true;
        }
    }

}
