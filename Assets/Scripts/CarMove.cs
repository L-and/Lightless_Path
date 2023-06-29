using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public Transform targetObject;
    public float movementSpeed = 5.0f;
    public AudioClip carClarkson;
    public float waittime=0;
    private AudioSource audioSource;
    private Vector3 direction;
    private bool isPaused=false;
    private bool isPaused1= false;
    private float timer = 0;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        // Ÿ�� ��ü�� ���ϴ� ���� ���� ���
        direction = targetObject.position - transform.position;
        direction.Normalize();
        timer += Time.deltaTime;
        if (timer > waittime)
        {
            // �̵� �ӵ��� �ð� ���� ���� ���
            float distance = Vector3.Distance(transform.position, targetObject.position);
            float moveDistance = movementSpeed * Time.deltaTime;
            if (isPaused != true && isPaused1 != true)
            {
                // �̵��� �Ÿ��� �����ִ� ��쿡�� �̵� ����
                if (moveDistance < distance)
                {
                    transform.position += direction * moveDistance;
                }
                else
                {
                    // ��ǥ ��ġ�� ������ ��� �̵� ����
                    transform.position = targetObject.position;
                    gameObject.SetActive(false);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            audioSource.clip = carClarkson;
            audioSource.Play();
            Debug.Log("detect");
        }
        if (collision.collider.gameObject.CompareTag("Car"))
        {
            isPaused1 = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            transform.position += direction * 0;
            Debug.Log("stay");
            isPaused = true;
        }
        if (collision.collider.gameObject.CompareTag("Car"))
        {
            transform.position += direction * 0;
            Debug.Log("stay");
            isPaused1 = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            isPaused = false;
        }
        if (collision.collider.gameObject.CompareTag("Car"))
        {
            isPaused1 = false;
        }
    }
}
