using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
   
    float sec = 0;
    int display = 0;
    public PauseMenu pm;

   
    void FixedUpdate()
    {
        if ( pm.checkPause() == false)
        {
            sec += Time.fixedDeltaTime;
            if (sec >= 1f)
            {
                display += 1;
                sec = 0;
            }
            TimerText.text = display.ToString() + "s";
            // "Timer:\n" +
        }
    }

    public int getTime()
    {
        return display;
    }
}
