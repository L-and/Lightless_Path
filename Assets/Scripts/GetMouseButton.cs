using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMouseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2,0));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "waitbutton")
            
                Debug.Log("�ǳʼ���");
            }
            if (hit.transform.gameObject.tag == "waitbutton")
            {
                AudioSource Start = GetComponent<AudioSource>();
                Start.Play();
            }
        }

    }
}