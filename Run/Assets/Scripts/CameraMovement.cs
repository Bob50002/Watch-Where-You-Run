using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float RotationX = 0f;

    [SerializeField] float RotationY = 0f;

    [SerializeField] float DegreeLimit = 0f;

    [SerializeField] float sensitivity = 15f;

    [SerializeField] float CamSpeed = 0f;

   

    private bool CamVisibility = true;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        CamMovement();

        CamLook();

        CursorVisible();
      
    }



    private void CamMovement()
    {
        Input.GetAxisRaw("Horizontal");

        Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.position += -transform.right * CamSpeed * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.position += transform.right * CamSpeed * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.position += -transform.forward * CamSpeed * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.position += transform.forward * CamSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.position += transform.up * CamSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.position += -transform.up * CamSpeed * Time.deltaTime;
        }
    }

    private void CamLook()
    {
        RotationY += Input.GetAxis("Mouse X") * sensitivity;

        RotationX += Input.GetAxis("Mouse Y") * -sensitivity;

        RotationX = Mathf.Clamp(RotationX, -DegreeLimit, DegreeLimit);

        transform.rotation = Quaternion.Euler(RotationX, RotationY, 0);
    }

    private void CursorVisible()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            CamVisibility = !CamVisibility;
        }

        if (CamVisibility == false)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
