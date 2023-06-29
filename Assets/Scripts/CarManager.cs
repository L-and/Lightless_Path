using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField]
    GameObject car;

    void Start()
    {
        StartCoroutine("CarAwakeCoroutine");
    }

    IEnumerator CarAwakeCoroutine()
    {
        yield return new WaitForSeconds(4.0f);
        
        car.SetActive(true);
    }
}
