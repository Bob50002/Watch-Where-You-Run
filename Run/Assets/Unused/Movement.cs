using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator KnigtAnimator;

    [SerializeField] float VelocityX = 0.0f;

    [SerializeField] float VelocityY = 0.0f;

    [SerializeField] float WalkMaxValue;

    private float OriginalMaxValue;

    private float RunMaxValue;

    [SerializeField] float Speed;

    [SerializeField] float Recovery;

    void Start()
    {
        KnigtAnimator = GetComponent<Animator>();

        RunMaxValue = WalkMaxValue * 2;

        OriginalMaxValue = WalkMaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        bool HoldDownShift = Input.GetKey(KeyCode.LeftShift);

        if (HoldDownShift)
        {
            WalkMaxValue = RunMaxValue;
        }
        else
        {
            WalkMaxValue = OriginalMaxValue;
        }



        if (Input.GetKey(KeyCode.W))
        {
            VelocityY = Mathf.MoveTowards(VelocityY, WalkMaxValue, Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            VelocityY = Mathf.MoveTowards(VelocityY, -WalkMaxValue, Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            VelocityX = Mathf.MoveTowards(VelocityX, -WalkMaxValue, Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            VelocityX = Mathf.MoveTowards(VelocityX, WalkMaxValue, Speed * Time.deltaTime);
        }



        if (Input.anyKey != true && VelocityX != 0)
        {
            VelocityX = Mathf.MoveTowards(VelocityX, 0, Recovery * Time.deltaTime);  
        }

        if (Input.anyKey != true && VelocityY != 0)
        {
           VelocityY = Mathf.MoveTowards(VelocityY, 0, Recovery * Time.deltaTime);
        }

        KnigtAnimator.SetFloat("MoveY", VelocityY);

        KnigtAnimator.SetFloat("MoveX", VelocityX);    
    }
}
