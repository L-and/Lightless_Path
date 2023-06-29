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
        // 타겟 객체로 향하는 방향 벡터 계산
        direction = targetObject.position - transform.position;
        direction.Normalize();

        // 이동 속도와 시간 간의 관계 계산
        float distance = Vector3.Distance(transform.position, targetObject.position);
        float moveDistance = movementSpeed * Time.deltaTime;
        if (isPaused != true)
        {
            // 이동할 거리가 남아있는 경우에만 이동 수행
            if (moveDistance < distance)
            {
                transform.position += direction * moveDistance;
            }
            else
            {
                // 목표 위치에 도달한 경우 이동 종료
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
