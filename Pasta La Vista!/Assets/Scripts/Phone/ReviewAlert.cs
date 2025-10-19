using UnityEngine;
using System.Collections;

public class ReviewAlert : MonoBehaviour
{
    public Review review;
    public AudioSource audioSource;
    public AudioClip positiveReview;
    bool clipPlayed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!clipPlayed)
        {
            
        if (review.reviewScore == 3000)
        {
            StartCoroutine(reviewSound());

            if (clipPlayed)
            {
                    StopCoroutine(reviewSound());
                    clipPlayed = false;
            }
        }

        else if (review.reviewScore == 4000 )
        {
            StartCoroutine(reviewSound());

            if (clipPlayed)
            {
                    StopCoroutine(reviewSound());
                    clipPlayed = false;
            }
        }

        else if (review.reviewScore == 5000)
        {
        
            StartCoroutine(reviewSound());

            if (clipPlayed)
            {
                    StopCoroutine(reviewSound());
                    clipPlayed = false;
            }

        }
        }

    }
    
    IEnumerator reviewSound()
    {   
        
        yield return new WaitForSeconds(1f);
        clipPlayed = true;
    }
}
