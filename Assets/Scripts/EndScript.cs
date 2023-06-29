using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    [SerializeField]
    string endText;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            UIManger.Instance.setStoryText(endText);

            UIManger.Instance.setMissionText("");
        }
    }
}
