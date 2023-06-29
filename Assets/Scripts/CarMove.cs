using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public Transform targetObject;
    public float movementSpeed = 5.0f;
    public AudioClip carClarkson;
    private AudioSource audioSource;
    private Vector3 direction;
    private bool isPaused=false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        // Ÿ�� ��ü�� ���ϴ� ���� ���� ���
        direction = targetObject.position - transform.position;
        direction.Normalize();

        // �̵� �ӵ��� �ð� ���� ���� ���
        float distance = Vector3.Distance(transform.position, targetObject.position);
        float moveDistance = movementSpeed * Time.deltaTime;
        if (isPaused != true)
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            audioSource.clip = carClarkson;
            audioSource.Play();
            Debug.Log("detect");
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
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            isPaused = false;
        }
    }
}
