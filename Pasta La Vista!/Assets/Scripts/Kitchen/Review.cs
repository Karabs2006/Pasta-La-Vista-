using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Review : MonoBehaviour
{
    public int reviewScore = 3000;

    [Header("Stars")]
        public Image starOne;
        public Image starTwo;
        public Image starThree;
        public Image starFour;
        public Image starFive;
        public List<Image> stars;

    void Start()
    {
        stars.Add(starOne);
        stars.Add(starTwo);
        stars.Add(starThree);
        stars.Add(starFour);
        stars.Add(starFive);
    }


    void Update()
    {
        if (reviewScore == 5000)
        {
            foreach (Image star in stars)
            {
                star.enabled = true;
            }
            ;
        }

        else if (reviewScore >= 4000 && reviewScore < 5000)
        {
            stars[0].enabled = true;
            stars[1].enabled = true;
            stars[2].enabled = true;
            stars[3].enabled = true;
            stars[4].enabled = false;

        }

        else if (reviewScore >= 3000 && reviewScore < 4000)
        {
            stars[0].enabled = true;
            stars[1].enabled = true;
            stars[2].enabled = true;
            stars[3].enabled = false;
            stars[4].enabled = false;

        }

        else if (reviewScore >= 2000 && reviewScore < 3000)
        {
            stars[0].enabled = true;
            stars[1].enabled = true;
            stars[2].enabled = false;
            stars[3].enabled = false;
            stars[4].enabled = false;

        }

        else if (reviewScore >= 1000 && reviewScore < 2000)
        {
            stars[0].enabled = true;
            stars[1].enabled = false;
            stars[2].enabled = false;
            stars[3].enabled = false;
            stars[4].enabled = false;
        }

        else if (reviewScore == 0)
        {

            SceneManager.LoadSceneAsync("GameOverScene");
            /*foreach (Image star in stars)
            {
                star.enabled = false;
            }
            ;

            SceneManager.LoadSceneAsync("GameOverScene");
            */

        }
    }
    
    
}
