using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class SteveReview : MonoBehaviour
{   
    [Header("Stars")]
        public Image starOne;
        public Image starTwo;
        public Image starThree;
        public Image starFour;
        public Image starFive;
        public List<Image> stars;
        
    void Start()
    {
        stars = new List<Image> { starOne, starTwo, starThree, starFour, starFive};
        stars[2].enabled = false;
        stars[3].enabled = false;
        stars[4].enabled = false;
    }
    
    public IEnumerator Review()
    {
        yield return new WaitForSeconds(30f);
        stars[2].enabled = true;
        yield return new WaitForSeconds(20f);
        stars[3].enabled = true;
        yield return new WaitForSeconds(40f);
        stars[4].enabled = true;
        yield return new WaitForSeconds(30f);
        stars[4].enabled = false;
        stars[3].enabled = false;
        yield return new WaitForSeconds(20f);
        stars[3].enabled = true;
    }
}
