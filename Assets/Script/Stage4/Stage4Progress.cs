using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage4Progress : MonoBehaviour
{
    [SerializeField] private Slider Progressbar;
    private Text ClearText = null;
    // Start is called before the first frame update
    void Start()
    {
        Progressbar = GameObject.Find("Progress").GetComponent<Slider>();
        ClearText = GameObject.Find("Clear").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        progress();
        if (Stage4GrabObjectInteraction.cnt == 1)
        {
            ClearText.text = "Clear!";
            PlayerPrefs.SetInt("stage4", 1);
            PlayerPrefs.Save();
            Invoke("Loader", 5f);
        }
    }
    // ÁøÇàµµ
    void progress()
    {
        Progressbar.value = (float)Stage4_GrabInteraction.cnt / 1f;
    }
    void Loader()
    {
        SceneManager.LoadScene("stage5");
    }
}
