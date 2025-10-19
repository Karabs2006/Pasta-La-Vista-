using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SteveReview steveReview;
    public PhoneTime phoneTime;
    public GameObject controls;
    void Start()
    {   

        StartCoroutine(steveReview.Review());
        StartCoroutine(phoneTime.Timer());
        StartCoroutine(ShowControls());
    }

    IEnumerator ShowControls()
    {
        yield return new WaitForSeconds(20f);
        controls.SetActive(false);
    }
    public void Controls()
    {
         controls.SetActive(true);
    }
}
