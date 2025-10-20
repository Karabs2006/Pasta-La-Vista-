using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Phone : MonoBehaviour
{
    public FPController fPController;
    public GameObject phone;
    public GameObject pauseMenu;
    public Review review;
    public AudioSource audioSource;
    public AudioClip equipPhone;

    [Header("Stars")]
        public Image starOne;
        public Image starTwo;
        public Image starThree;
        public Image starFour;
        public Image starFive;
        public List<Image> stars;

    void Start()
    {
        phone.SetActive(false);
        stars.Add(starOne);
        stars.Add(starTwo);
        stars.Add(starThree);
        stars.Add(starFour);
        stars.Add(starFive);
    }

    void Update()
    {
        if (fPController.phonePressed)
        {
            phone.SetActive(true);
            audioSource.PlayOneShot(equipPhone);
            fPController.phonePressed = false;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fPController.lookSensitivity = 0f;
        }


        if (review.reviewScore == 5000)
        {
            foreach (Image star in stars)
            {
                star.enabled = true;
            };
        }

        else if (review.reviewScore >= 4000 && review.reviewScore < 5000)
        {
            stars[0].enabled = true;
            stars[1].enabled = true;
            stars[2].enabled = true;
            stars[3].enabled = true;
            stars[4].enabled = false; ;
        }

        else if (review.reviewScore >= 3000 && review.reviewScore < 4000)
        {
            stars[0].enabled = true;
            stars[1].enabled = true;
            stars[2].enabled = true;
            stars[3].enabled = false;
            stars[4].enabled = false; ;
        }

        else if (review.reviewScore >= 2000 && review.reviewScore< 3000)
        {
            stars[0].enabled = true;
            stars[1].enabled = true;
            stars[2].enabled = false;
            stars[3].enabled = false;
            stars[4].enabled = false; ;
        }

        else if (review.reviewScore >= 1000 && review.reviewScore < 2000)
        {
            stars[0].enabled = true;
            stars[1].enabled = false;
            stars[2].enabled = false;
            stars[3].enabled = false;
            stars[4].enabled = false;
        }

        else if (review.reviewScore == 0)
        {
            foreach (Image star in stars)
            {
                star.enabled = false;
            }
            ;
        }
    }


    public void ResumeGame()
    {
        phone.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 2f;
    }

    

    
}


    




