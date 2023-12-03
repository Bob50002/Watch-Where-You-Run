//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Com_MovingObject : MonoBehaviour , IInteractable
//{
//     private Vector3 StartPosition;
//    [SerializeField] GameObject EndPosition;
//    [SerializeField] float MoveSpeed;
//    [SerializeField] float Delay;

//    private enum TrueOrFalse
//    {
//        True,

//        False
//    }

//    void start()
//    {
//        StartPosition = this.transform.position;

//        //DoSomething(True);
//    }

//    void Update()
//    {
     
//    }

//    public void DoSomething(bool Activate)
//    {
//        if (Activate == true)
//        {
//            this.gameObject.transform.position += Vector3.up * MoveSpeed * Time.deltaTime;
//        }

//        if (Activate == false)
//        {
//            this.gameObject.transform.position += Vector3.down * MoveSpeed * Time.deltaTime;
//        }

//    }

//    private IEnumerator MoveToEndPosition()
//    {
//        transform.position = Vector3.MoveTowards(StartPosition, EndPosition.transform.position, MoveSpeed * Time.deltaTime);

//        yield return new WaitForSeconds(Delay);
//    }

//    private IEnumerator MoveToStartPosition()
//    {
//        transform.position = Vector3.MoveTowards(StartPosition, EndPosition.transform.position, MoveSpeed * Time.deltaTime);

//        yield return new WaitForSeconds(Delay);
//    }

//    private void OnDrawGizmos()
//    {
//        Gizmos.DrawLine(this.transform.position, EndPosition.transform.position);
//    }
//}
