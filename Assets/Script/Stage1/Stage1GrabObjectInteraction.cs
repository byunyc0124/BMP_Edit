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
    private Text ExplanationText = null;
    private Text ClearText = null;

    // misson
    public static int cnt = 0;


    private void Start()
    {
        ps = GameObject.Find("WaterEffect").GetComponent<ParticleSystem>();
        // UI
        Timer = GameObject.Find("Timer").GetComponent<Slider>();
        Progress = GameObject.Find("Progress").GetComponent<Slider>();
        TimerText = GameObject.Find("Text").GetComponent<Text>();
        ExplanationText = GameObject.Find("Explanation").GetComponent<Text>();
        ClearText = GameObject.Find("Clear").GetComponent<Text>();
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
        else // 제한 시간 초과로 게임 실패
        {
            ClearText.text = "Timeout!";
            PlayerPrefs.SetInt("stage1", 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene("stage2");
        }

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            Destroy(glow);
            ExplanationText.text = "물뿌리개로 3개의 온실에 물을 주세요.";
            if (isWatered != primary)
            {
                isWatered = primary; // button on trigger
                if (isWatered)
                {
                    ps.Play();
                    SoundManger.instance.SFXPlay("liquid", clip);
                    cnt++;
                }
                else
                {
                    ps.Stop();
                }
            }
        }
    }
    
}
