using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Stage5GrabInteraction : MonoBehaviour
{
    public XRController controller = null;

    // water animation
    private bool isFeed = false; // 사료 뿌린 상태 초기값 false
    [SerializeField] private ParticleSystem ps;
    public GameObject glow;
    private Text expText = null;

    private Animator cow1 = null;
    private Animator cow2 = null;

    // misson
    public static int cnt = 0;

    private void Start()
    {
        ps = GameObject.Find("FeedEffect").GetComponent<ParticleSystem>();
        cow1 = GameObject.Find("Cow (1)").GetComponent<Animator>();
        cow2 = GameObject.Find("Cow (2)").GetComponent<Animator>();
        expText = GameObject.Find("Explanation").GetComponent<Text>();

    }

    private void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            if(CompareTag("L1")) { 
                Destroy(glow);
                expText.text = "A 버튼을 눌러 사료를 주세요!";
                if (isFeed != primary)
                {
                    isFeed = primary; // button on trigger
                    if (isFeed)
                    {
                        Destroy(glow);
                        ps.Play();
                        cow1.SetBool("Eat", true);
                        //cow2.SetBool("Eat", true);
                        cnt++;
                    }
                    else
                    {
                        ps.Stop();
                    }
                }
            }

            if (CompareTag("L2"))
            {
                Destroy(glow);
                expText.text = "A 버튼을 눌러 사료를 주세요!";
                if (isFeed != primary)
                {
                    isFeed = primary; // button on trigger
                    if (isFeed)
                    {
                        Destroy(glow);
                        ps.Play();
                        //cow1.SetBool("Eat", true);
                        cow2.SetBool("Eat", true);
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
}
