using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] Transform Player;

    [SerializeField] float MouseSensitivity;

    [SerializeField] float CameraVerticalMove;

    [SerializeField] float CameraLimit;

    private bool LockCamera;
    void Start()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float InputX = Input.GetAxis("Mouse X") * MouseSensitivity;

        float InputY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        CameraVerticalMove -= InputY;

        CameraVerticalMove = Mathf.Clamp(CameraVerticalMove, -CameraLimit, CameraLimit);

        transform.localEulerAngles = Vector3.right * CameraVerticalMove;

        Player.Rotate(Vector3.up * InputX);
    }
}
