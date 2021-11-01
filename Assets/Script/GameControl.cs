using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [SerializeField] float playTime = 45f;

    // Update is called once per frame
    void Update()
    {
        EndTime();
    }

    void EndTime()
    {
        if(RemainTime.rTime <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
