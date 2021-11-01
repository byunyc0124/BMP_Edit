using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage3Progress : MonoBehaviour
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
        if (Stage1GrabObjectInteraction.cnt == 1)
        {
            PlayerPrefs.SetInt("stage3", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("stage3");
        }
    }
    // ÁøÇàµµ
    void progress()
    {
        Progressbar.value = (float)Stage3GrabInteraction.cnt / 1f;
    }
}
