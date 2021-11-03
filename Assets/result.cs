using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{
    // 땅 뒤집기
    private Animator switch1;
    private Animator switch2;
    private Animator switch3;
    private Animator switch4;
    private Animator switch5;

    Renderer st1Color;
    Renderer st2Color;
    Renderer st3Color;
    Renderer st4Color;
    Renderer st5Color;
    // Start is called before the first frame update
    void Start()
    {
        //땅 뒤집는거
        switch1 = GameObject.Find("stage1").GetComponent<Animator>();
        switch2 = GameObject.Find("stage2").GetComponent<Animator>();
        switch3 = GameObject.Find("stage3").GetComponent<Animator>();
        switch4 = GameObject.Find("stage4").GetComponent<Animator>();
        switch5 = GameObject.Find("stage5").GetComponent<Animator>();
        st1Color = GameObject.Find("HexSt1").GetComponent<Renderer>();
        st2Color = GameObject.Find("HexSt2").GetComponent<Renderer>();
        st3Color = GameObject.Find("HexSt3").GetComponent<Renderer>();
        st4Color = GameObject.Find("HexSt4").GetComponent<Renderer>();
        st5Color = GameObject.Find("HexSt5").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bbomul();
    }

    // 땅 뒤집기 일단 데이터 1인 경우(clear) 뒤집히게 해놨어!
    void bbomul()
    {
        if (PlayerPrefs.HasKey("stage1"))
        {
            if (PlayerPrefs.GetInt("stage1") == 1)
            {
                switch1.SetBool("Rotate", true);
                st1Color.material.color = new Color(255, 127, 0);
            }
            else
            {
                switch1.SetBool("Rotate", true);
                st1Color.material.color = Color.gray;
            }
        }
        if (PlayerPrefs.HasKey("stage2"))
        {
            if (PlayerPrefs.GetInt("stage2") == 1)
            {
                switch2.SetBool("Rotate", true);
                st2Color.material.color = new Color(255, 127, 0);
            }
            else
            {
                switch2.SetBool("Rotate", true);
                st2Color.material.color = Color.gray;
            }
        }
        if (PlayerPrefs.HasKey("stage3"))
        {
            if (PlayerPrefs.GetInt("stage3") == 1)
            {
                switch3.SetBool("Rotate", true);
                st3Color.material.color = new Color(255, 127, 0);
            }
            else
            {
                switch3.SetBool("Rotate", true);
                st3Color.material.color = Color.gray;
            }
        }
        if (PlayerPrefs.HasKey("stage4"))
        {
            if (PlayerPrefs.GetInt("stage4") == 1)
            {
                switch4.SetBool("Rotate", true);
                st4Color.material.color = new Color(255, 127, 0);
            }
            else
            {
                switch4.SetBool("Rotate", true);
                st4Color.material.color = Color.gray;
            }
        }
        if (PlayerPrefs.HasKey("stage5"))
        {
            if (PlayerPrefs.GetInt("stage5") == 1)
            {
                switch5.SetBool("Rotate", true);
                st5Color.material.color = new Color(255, 127, 0);
            }
            else
            {
                switch5.SetBool("Rotate", true);
                st5Color.material.color = Color.gray;
            }
        }

        Invoke("gotoboard", 7f);
    }

    void gotoboard()
    {
        SceneManager.LoadScene("freeboard");
    }
}
