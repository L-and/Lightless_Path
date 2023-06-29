using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOffTimer : MonoBehaviour
{


    [SerializeField]
    int delay;

    void Start()
    {
        Time.timeScale = 0.1f;

        Invoke("getOffUI", delay);
    }

    void getOffUI()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
