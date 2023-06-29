using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEventTriggerSelecter : MonoBehaviour
{
    UIManger uiManager;
    
    public enum Type
    {
        Story, Tip, Mission
    };

    public Type type;

    [SerializeField]
    private string text;

    void Start()
    {
        uiManager = UIManger.Instance;

        Debug.Log(text);
    }

    // triger collider 진입 시 Text 변경
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(type == Type.Story)
            {
                UIManger.Instance.setStoryText(text);
            }
            else if(type == Type.Tip)
            {   
                Debug.Log(gameObject.tag);
                if (gameObject.tag == "brailleBlock")
                {
                    UIManger.Instance.setTipText("유도블럭이 발에 느껴진다..");
                }
                else
                {
                    UIManger.Instance.setTipText(text);
                }
            }
            else if(type == Type.Mission)
            {
                UIManger.Instance.setMissionText(text);
            }
        }
    }

    // triger collider 탈출 시 Text 초기화
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(type == Type.Story)
            {
                UIManger.Instance.setStoryText("");
            }
            else if(type == Type.Tip)
            {
                UIManger.Instance.setTipText("");
            }
            else if(type == Type.Mission)
            {
                UIManger.Instance.setMissionText("");
            }
        }   
    }
}
