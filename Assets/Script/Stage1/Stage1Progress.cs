using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1Progress : MonoBehaviour
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
        if(Stage1GrabObjectInteraction.cnt == 2)
        {
            PlayerPrefs.SetInt("stage1", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("stage2");
        }
    }
    // ���൵
    void progress()
    {
        Progressbar.value = (float)Stage1GrabObjectInteraction.cnt / 2f;
    }
}
