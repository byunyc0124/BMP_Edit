using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage5Progress : MonoBehaviour
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
        if (Stage1GrabObjectInteraction.cnt == 2)
        {
            ClearText.text = "Clear!";
            PlayerPrefs.SetInt("stage5", 1);
            PlayerPrefs.Save();
            Invoke("Loader", 5f);
        }
    }
    // ÁøÇàµµ
    void progress()
    {
        Progressbar.value = (float)Stage5GrabInteraction.cnt / 2f;
    }
    void Loader()
    {
        SceneManager.LoadScene("tutorialboard");
    }
}
