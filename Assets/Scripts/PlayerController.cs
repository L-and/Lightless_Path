using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;

    Vector3 moveDir;
    float dirX;
    float dirZ;

    float rotateHorizontal;
    float rotateVertical;
     
    float verticalRotation;

    public Camera playerCamera;

    [SerializeField]
    float speed;

    [SerializeField]
    float mouseSensitivity;

    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();

        playerCamera = gameObject.GetComponent<Transform>().FindChild("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        playerInput();
        move();
        screenRotate();
        
    }

    private void playerInput()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirZ = Input.GetAxisRaw("Vertical");

        rotateHorizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotateVertical = Input.GetAxis("Mouse Y") * mouseSensitivity;

        moveDir = new Vector3(
            dirX, 
            0, 
            dirZ);
    }


    private void move()
    {
        moveDir = transform.forward * dirZ + transform.right * dirX;
        
        playerTransform.position = Vector3.MoveTowards(playerTransform.position, playerTransform.position + moveDir, Time.deltaTime * speed);
    }

    private void screenRotate()
    {
        playerTransform.Rotate(0f, rotateHorizontal, 0f);

        verticalRotation -= rotateVertical;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
