using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp : MonoBehaviour
{
    public  GameObject[] tmpObject;

    private void Start()
    {
        foreach(GameObject obj in tmpObject)
        {
            GameObject childObject = obj.GetComponent<Transform>().GetChild(0).gameObject;
            childObject.tag = "brailleBlock";
            childObject.GetComponent<TextEventTriggerSelecter>().type = TextEventTriggerSelecter.Type.Tip;
        }
    }
}
