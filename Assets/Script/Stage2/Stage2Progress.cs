using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2Progress : MonoBehaviour
{
    [SerializeField] private Slider Progressbar;
    // Start is called before the first frame update
    void Start()
    {
        Progressbar = GameObject.Find("Progress").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        progress();
    }
    // ���൵
    void progress()
    {
        Progressbar.value = (float)Stage2GrabInteraction.cnt / 2f;
    }
}
