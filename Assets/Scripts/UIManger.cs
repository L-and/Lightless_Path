using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManger : MonoBehaviour
{
    private static UIManger instance = null;

    // Singleton Instance에 접근하기 위한 프로퍼티
    public static UIManger Instance
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
    GameObject storyText; // 대본 텍스트를 출력하는 Text UI object
    
    [SerializeField]
    GameObject missionText; // 미션 텍스트를 출력하는 Text UI object

    [SerializeField]
    GameObject tipText; // 팁 텍스트를 출력하는 Text UI object
    
    public void setStoryText(string text)
    {
        storyText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void setMissionText(string text)
    {
        missionText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void setTipText(string text)
    {
        tipText.GetComponent<TextMeshProUGUI>().text = text;
    }
}
