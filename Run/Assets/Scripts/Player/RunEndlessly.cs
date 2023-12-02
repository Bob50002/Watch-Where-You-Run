using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEndlessly : MonoBehaviour
{
    private Rigidbody MainCharacter;
    [SerializeField] float MoveSpeed;
    [SerializeField] FirstPersonCamera PlayerDirection;


    void Start()
    {
        MainCharacter = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        //MainCharacter.position += transform.forward * MoveSpeed * Time.deltaTime;

        MainCharacter.velocity = transform.forward * MoveSpeed * Time.deltaTime;
    }
}
