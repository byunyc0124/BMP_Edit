using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainTime : MonoBehaviour
{
    public Slider timerSlider;
    Text text;
    public static float rTime = 45f;
    private bool stopTimer;

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = rTime;
        timerSlider.value = rTime;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        rTime -= Time.deltaTime;
        text.text = Mathf.Round(rTime) + "√ ";

        if (rTime < 0) { 
            rTime = 0;
            stopTimer = true;
        }

        if (stopTimer == false)
        {
            text.text = "0";
            timerSlider.value = rTime;
        }
    }
}
