using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caraction : MonoBehaviour
{

    public AudioClip carClarkson;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            audioSource.clip = carClarkson;
            audioSource.Play();
            Debug.Log("detect");
        }
        if (collision.collider.gameObject.CompareTag("goal"))
        {
            Debug.Log("goal");
            //SceneManager.LoadScene("nextScene");
        }
    }
}
