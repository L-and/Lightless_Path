using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptManager : MonoBehaviour
{
    private static ScriptManager instance = null;

    // Singleton Instance에 접근하기 위한 프로퍼티
    public static ScriptManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    string stage1Text;
    [SerializeField]
    string stage2Text;

    [SerializeField]
    int delayTime;

    public void stage1()
    {
        StartCoroutine("stage1Coroutine");
    }

    public void stage2()
    {
        StartCoroutine("stage2Coroutine");
    }

    IEnumerator stage1Coroutine()
    {
        UIManger.Instance.setStoryText(stage1Text);
        Time.timeScale = 0.1f;

        yield return new WaitForSecondsRealtime(delayTime);

        Time.timeScale = 1.0f;
        UIManger.Instance.setStoryText("");
    }

    IEnumerator stage2Coroutine()
    {
        UIManger.Instance.setStoryText(stage2Text);
        Time.timeScale = 0.1f;

        yield return new WaitForSecondsRealtime(delayTime);

        UIManger.Instance.setStoryText("");
        Time.timeScale = 1.0f;
    }

}
