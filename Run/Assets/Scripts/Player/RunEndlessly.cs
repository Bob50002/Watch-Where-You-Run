using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEndlessly : MonoBehaviour
{
    private Rigidbody MainCharacter;
    [SerializeField] float MoveSpeed;
    [SerializeField] FirstPersonCamera PlayerDirection;

    private float MovementX;


    void Start()
    {
        MainCharacter = this.GetComponent<Rigidbody>();
    }

   
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        //MainCharacter.position += transform.forward * MoveSpeed * Time.deltaTime;

        Vector3 MovementVelocity = transform.forward * MoveSpeed * Time.deltaTime;

        MainCharacter.velocity = new Vector3(MovementVelocity.x, MainCharacter.velocity.y, MovementVelocity.z);
    }
}
