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

    // misson
    public static int cnt = 0;

    private void Start()
    {
        ps = GameObject.Find("FeedEffect").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            if (isFeed != primary)
            {
                isFeed = primary; // button on trigger
                if (isFeed)
                {
                    Destroy(glow);
                    ps.Play();
                }
                else
                {
                    ps.Stop();
                }  
            }
        }
    }
}
