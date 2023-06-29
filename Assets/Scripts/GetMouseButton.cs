using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMouseButton : MonoBehaviour
{
    [SerializeField]
    GameObject wallObject;

    [SerializeField]
    GameObject carHornArea;

    [SerializeField]
    int trafficLightDuration;

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

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "waitbutton")
                {
                    Debug.Log("Hit Button");    

                    wallObject.SetActive(false); // 벽오브젝트 비활성화
                    AudioSource Start = GetComponent<AudioSource>();    
                    Start.Play();


                    // 신호등 종료(빨간불)
                    StartCoroutine("TrafficLightOffCoroutine");
                }
            }
        }

    }

    IEnumerator TrafficLightOffCoroutine()
    {
        yield return new WaitForSeconds(trafficLightDuration);

        Debug.Log("신호등 Off!");
        carHornArea.SetActive(true);
    }
}