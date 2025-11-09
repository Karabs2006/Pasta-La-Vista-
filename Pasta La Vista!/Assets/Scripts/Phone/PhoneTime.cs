using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PhoneTime : MonoBehaviour
{
    public TMP_Text minutes;
    public TMP_Text hours;
    public Review review;
    int hoursClock = 13;
    bool gamePlaying = true;

    void Update()
    {
        if(hoursClock == 19)
        {
            if (review.reviewScore >= 4000)
            {
                SceneManager.LoadSceneAsync("WinScene");
            }

            if (review.reviewScore < 4000)
            {
                SceneManager.LoadSceneAsync("LoseScene");
            } 
        }
    }

    public IEnumerator Timer()
    {
        int mins = 0;

        while(gamePlaying)
        {
            mins++;

            if (mins <= 9)
            {
                minutes.text = "0" + mins;
                yield return new WaitForSeconds(1f);
            }

            else
            {
                minutes.text = $"{mins}";
                yield return new WaitForSeconds(1f);
            }

            if (mins >= 60)
            {
                hoursClock++;
                hours.text = $"{hoursClock}";
                mins = 0;
            }
        }
    }
}
