using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    
    [SerializeField] Camera FirstPersonCamera;
    [SerializeField] List<GameObject> LinkedComponent = new List<GameObject>();
    [SerializeField] Color LineColor;
    
    [SerializeField] Animator MCAnimator;
    private string SendSignal = "SendSignal";
    [SerializeField] LayerMask Mask;

    [SerializeField] GameObject Player;
    private bool Enable;
    RaycastHit Hit;

    private bool Activate;

    private void Start()
    {
        Enable = true;
    }

    private bool IsVisible(Camera C, GameObject PlayerCharacter)
    {
        var Planes = GeometryUtility.CalculateFrustumPlanes(C);

        var Point = PlayerCharacter.transform.position;

        foreach (var Plane in Planes)
        {
            if (Plane.GetDistanceToPoint(Point) < 0)
            {
                return false;
            }
        }

        return true;
    }

    private void Update()
    {
        if (IsVisible(FirstPersonCamera, this.gameObject) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (var Components in LinkedComponent)
            {
              Components.GetComponent<IInteractable>().DoSomething(!Activate);

              MCAnimator.SetTrigger(SendSignal);
            }
        }

        Debug.Log(IsNotObstructed());

        Debug.DrawLine(transform.position, Player.transform.position);
    }

    private bool IsNotObstructed()
    {
        if (Physics.Raycast(transform.position, Player.transform.position, out Hit, Mathf.Infinity, Mask))
        {
            return(true);        
        }
        else
        {
            return (false);
        }      
    }
           
    //private void Update()
    //{
    //    if (Physics.Raycast(transform.position, Player.transform.position, out var hit, Mathf.Infinity, Mask))
    //    {
    //        Debug.Log("See");
    //    }
    //    else
    //    {
    //        Debug.Log("Cannot see");
    //    }

    //    Debug.DrawLine(transform.position, Player.transform.position);
    //}

    private void OnDrawGizmosSelected()
    {
        if (LinkedComponent != null)
        {
            Gizmos.color = LineColor;

            for (int i = 0; i < LinkedComponent.Count; i++)
            {
                Gizmos.DrawLine(this.transform.position, LinkedComponent[i].transform.position);
            }

        }
    }
}