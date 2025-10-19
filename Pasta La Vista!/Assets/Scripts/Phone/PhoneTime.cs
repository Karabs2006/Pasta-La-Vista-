using System.Collections;
using UnityEngine;
using TMPro;

public class PhoneTime : MonoBehaviour
{
    public TMP_Text minutes;
    public TMP_Text hours;
    int hoursClock = 13;
    bool gamePlaying = true;
    
    void Start()
    {
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
