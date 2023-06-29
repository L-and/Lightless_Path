using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScriptController : MonoBehaviour
{
    [SerializeField]
    string text;

    [SerializeField]
    int delayTime;
    
    void Start()
    {
        StartCoroutine("stageCoroutine");
    }

    IEnumerator stageCoroutine()
    {
        UIManger.Instance.setStoryText(text);
        Time.timeScale = 0.1f;

        yield return new WaitForSecondsRealtime(delayTime);

        Time.timeScale = 1.0f;
        UIManger.Instance.setStoryText("");
    }
}
