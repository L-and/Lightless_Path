using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caraction : MonoBehaviour
{
    [SerializeField]
    UIManger uiManager;

    [SerializeField]
    GameObject ui;

    public AudioClip carClarkson;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("goal"))
        {
            Debug.Log("goal");
            Destroy(uiManager);
            Destroy(ui);

            SceneManager.LoadScene("stage_02");
        }

    }
}
