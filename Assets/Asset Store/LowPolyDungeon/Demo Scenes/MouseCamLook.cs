using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public bool lockVertical = true;
    public Vector3 positionOffset = Vector3.zero;
    public Vector3 rotationOffset = Vector3.zero;
    private Vector3 initialLocalPosition;
    float xRotation = 0f;    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = lockVertical ? 0f : Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        if (lockVertical)
        {
            xRotation = 0f;
        }
        else
        {
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        }

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f) * Quaternion.Euler(rotationOffset);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    void LateUpdate()
    {
        transform.localPosition = initialLocalPosition + positionOffset;
    }
}