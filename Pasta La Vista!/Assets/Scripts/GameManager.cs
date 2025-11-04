using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SteveReview steveReview;
    public PhoneTime phoneTime;
    public GameObject controls;
    public AudioSource buttonAudio;
    void Start()
    {   
        controls.SetActive(false);
        StartCoroutine(steveReview.Review());
        StartCoroutine(phoneTime.Timer());

    }

    
    public void Controls()
    {
        controls.SetActive(true);
        buttonAudio.Play();
    }
    
}
