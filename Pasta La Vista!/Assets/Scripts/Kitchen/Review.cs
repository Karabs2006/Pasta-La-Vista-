using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class Review : MonoBehaviour
{
    public int reviewScore = 3000;
    public TMP_Text rating;

    void Update()
    {
        if (reviewScore == 5000)
        {
            rating.text = "5";
        }
        else if (reviewScore >= 4000 && reviewScore < 5000)
        {
            rating.text = "4";
        }
        else if (reviewScore >= 3000 && reviewScore < 4000)
        {
            rating.text = "3";
        }
        else if (reviewScore >= 2000 && reviewScore < 3000)
        {
            rating.text = "2";
        }
        else if (reviewScore >= 1000 && reviewScore < 2000)
        {
            rating.text = "1";
        }
        else if (reviewScore == 0)
        {
            rating.text = "0";
            Debug.Log("GAME OVER. YOU SUCK!!!");
        }
    }
}
