using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1GrabObjectInteraction : MonoBehaviour
{
    public XRController controller = null;
    public AudioClip clip;

    // water animation
    private bool isWatered = false; // 물 뿌린 상태 초기값 false
    private bool buttonB = false;
    [SerializeField] private ParticleSystem ps;
    public GameObject glow;

    // UI
    [SerializeField] private Slider Timer;
    [SerializeField] private Slider Progress;
    private Text TimerText = null;

    // misson
    private int cnt = 0;


    private void Start()
    {
        ps = GameObject.Find("WaterEffect").GetComponent<ParticleSystem>();
        // UI
        Timer = GameObject.Find("Timer").GetComponent<Slider>();
        Progress = GameObject.Find("Progress").GetComponent<Slider>();
        TimerText = GameObject.Find("Text").GetComponent<Text>();
    }

    private void Update()
    {
        // 제한 시간
        if (Timer.value > 0.0f)
        {
            Timer.value -= Time.deltaTime;
            TimerText.text = Mathf.Floor(Timer.value).ToString();
            Invoke("progress", 5);
        }
        else
        {
            PlayerPrefs.SetInt("stage1", 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene("stage2");
        }

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            Destroy(glow);
            if (isWatered != primary)
            {
                isWatered = primary; // button on trigger
                if (isWatered)
                {
                    ps.Play();
                    SoundManger.instance.SFXPlay("liquid", clip);
                }
                else
                {
                    ps.Stop();
                }
            }
        }
    }
    
}
