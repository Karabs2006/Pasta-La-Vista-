using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SteveReview steveReview;
    public PhoneTime phoneTime;
    void Start()
    {
        StartCoroutine(steveReview.Review());
        StartCoroutine(phoneTime.Timer());
    }

    
    void Update()
    {
        
    }
}
