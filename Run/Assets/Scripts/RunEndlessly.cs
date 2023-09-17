using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEndlessly : MonoBehaviour
{
    [SerializeField] Rigidbody MainCharacter;

    [SerializeField] float MoveSpeed;

    [SerializeField] FirstPersonCamera PlayerDirection;

    private 

    void Start()
    {
        MainCharacter = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Input.GetAxisRaw("Horizontal");

        Input.GetAxisRaw("Vertical");

        //transform.rotation = Quaternion.Euler(90, 90, 0);

        MainCharacter.transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        //if (Input.GetAxisRaw("Vertical") == -1)
        //{
        //    MainCharacter.transform.position += -transform.forward * MoveSpeed * Time.deltaTime;
        //}

        //if (Input.GetAxisRaw("Vertical") == 1)
        //{
        //    MainCharacter.transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //}
    }
}
