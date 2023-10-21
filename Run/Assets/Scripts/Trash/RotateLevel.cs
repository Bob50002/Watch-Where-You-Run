using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            float RotationX = Input.GetAxis("Mouse X") * RotationSpeed;

            float RotationY= Input.GetAxis("Mouse Y") * RotationSpeed;

            transform.Rotate(Vector3.down, RotationX);

            transform.Rotate(Vector3.right, RotationY);
        }
     
    }
}
