using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Stage1LimitTime : MonoBehaviour
{
    // UI
    [SerializeField] private Slider Timer;
    private Text TimerText = null;
    private Text ClearText = null;

    // Start is called before the first frame update
    void Start()
    {
        // UI
        Timer = GameObject.Find("Timer").GetComponent<Slider>();
        TimerText = GameObject.Find("timertext").GetComponent<Text>();
        ClearText = GameObject.Find("Clear").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // 제한 시간
        if (Timer.value > 0.0f)
        {
            Timer.value -= Time.deltaTime;
            TimerText.text = Mathf.Floor(Timer.value).ToString();
        }
        else
        {
            ClearText.text = "Timeout!";
            PlayerPrefs.SetInt("stage1", 0);
            PlayerPrefs.Save();
            Invoke("Loader", 5f);
        }
    }

    void Loader()
    {
        SceneManager.LoadScene("stage2");
    }
}
