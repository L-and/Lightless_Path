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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (type == Type.Story)
            {
                UIManger.Instance.setStoryText(text);
            }
            else if (type == Type.Tip)
            {
                UIManger.Instance.setTipText(text);
            }
            else if (type == Type.Mission)
            {
                UIManger.Instance.setMissionText(text);
            }

        }
    }
}
