using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage6Progress : MonoBehaviour
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
            PlayerPrefs.SetInt("stage6", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("stage7");
        }
    }
    // ÁøÇàµµ
    void progress()
    {
        Progressbar.value = (float)Stage6GrabInteraction.cnt / 1f;
    }
}
