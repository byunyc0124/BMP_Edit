using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage5Progress : MonoBehaviour
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
        if (Stage1GrabObjectInteraction.cnt == 2)
        {
            PlayerPrefs.SetInt("stage5", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("stage6");
        }
    }
    // ÁøÇàµµ
    void progress()
    {
        Progressbar.value = (float)Stage5GrabInteraction.cnt / 2f;
    }
}
