using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHornSoundController : MonoBehaviour
{
    AudioSource carHornSound;

    private void Start()
    {
        carHornSound = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        carHornSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        carHornSound.Stop();
    }
}
