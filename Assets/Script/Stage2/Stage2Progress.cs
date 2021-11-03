using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2Progress : MonoBehaviour
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
        if (Stage2GrabInteraction.cnt == 2)
        {
            ClearText.text = "Clear!";
            PlayerPrefs.SetInt("stage2", 1);
            PlayerPrefs.Save();
            Invoke("Loader", 5f);
        }
    }
    // ÁøÇàµµ
    void progress()
    {
        Progressbar.value = (float)Stage2GrabInteraction.cnt / 2f;
    }
    void Loader()
    {
        SceneManager.LoadScene("stage3");
    }
}
