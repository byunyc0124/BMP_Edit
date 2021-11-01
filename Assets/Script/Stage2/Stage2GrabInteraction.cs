using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage2GrabInteraction : MonoBehaviour
{
    public XRController controller = null;
    public Animator animator = null;
    private bool isDowned = false; // 버튼 초기 상태
    public GameObject glow;

    // curtain
    private Animator curtain_animator = null;
    private Animator curtain_animator2 = null;

    // misson
    public static int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        curtain_animator = GameObject.Find("curtain_1").GetComponent<Animator>();
        curtain_animator2 = GameObject.Find("curtain_2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt == 2)
        {
            PlayerPrefs.SetInt("stage2", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("stage3");
        }

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            if (CompareTag("L1"))
            {
                Destroy(glow);
                if (isDowned != primary)
                {
                    isDowned = primary; // button on trigger
                    if (isDowned)
                    {
                        animator.SetBool("isDown", true);
                        curtain_animator.SetBool("Close", true);
                        cnt++;
                    }
                    else
                    {
                        animator.SetBool("isDown", false);
                        curtain_animator.SetBool("Close", false);
                    }
                }
            }

            if (CompareTag("L2"))
            {
                //Destroy(glow);
                if (isDowned != primary)
                {
                    isDowned = primary; // button on trigger
                    if (isDowned)
                    {
                        animator.SetBool("isDown", true);
                        curtain_animator2.SetBool("Close2", true);
                        cnt++;
                    }
                    else
                    {
                        animator.SetBool("isDown", false);
                        curtain_animator2.SetBool("Close2", false);
                    }
                }
            }
        }
    }

   
}
