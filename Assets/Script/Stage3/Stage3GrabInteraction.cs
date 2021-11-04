using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Stage3GrabInteraction : MonoBehaviour
{
    public XRController controller = null;
    private bool isDowned = false; // ��ư �ʱ� ����
    public GameObject glow;
    public Transform other;

    private Animator bt1 = null;
    private Animator bt3 = null;

    private Animator rabbit1 = null;
    private Animator rabbit2 = null;
    private Animator rabbit3 = null;

    [SerializeField] public ParticleSystem water1;
    [SerializeField] public ParticleSystem water2;
    [SerializeField] public ParticleSystem water3;


    // misson
    public static int cnt = 0;

    void Start()
    {
        bt1 = GameObject.Find("button3push").GetComponent<Animator>();
        bt3 = GameObject.Find("button5push").GetComponent<Animator>();
        rabbit1 = GameObject.Find("WhiteRabbit1").GetComponent<Animator>();
        rabbit2 = GameObject.Find("WhiteRabbit2").GetComponent<Animator>();
        rabbit3 = GameObject.Find("WhiteRabbit3").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            Debug.Log("Distance to other : " + dist);
            if (dist <= 0.3f && CompareTag("B3"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            bt1.SetBool("isPush", true);
                            cnt++;
                        }
                        else
                        {
                            bt1.SetBool("isPush", false);
                            water1.Play();
                            water2.Play();
                            water3.Play();
                            Invoke("rabbitawake", 2);
                        }
                    }
                }
            }

            if (dist <= 0.3f && CompareTag("B5"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            bt3.SetBool("isPush", true);
                        }
                        else
                        {
                            bt3.SetBool("isPush", false);
                        }
                    }
                }
            }
        }
    }
    void rabbitawake()
    {
        rabbit1.SetBool("Ok", true);
        rabbit2.SetBool("Ok", true);
        rabbit3.SetBool("Ok", true);
    }

}
