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
    [SerializeField] float Range;
    [SerializeField] LayerMask Mask;
    [SerializeField] Transform RaycastStartingPosition;
    [SerializeField] GameObject PlayerPosition;
    RaycastHit Hit;
    private bool Activate;

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
        if (IsVisible(FirstPersonCamera, this.gameObject))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && IsNotObstructed())
            {
                foreach (var Components in LinkedComponent)
                {
                    Components.GetComponent<IInteractable>().DoSomething(!Activate);

                    MCAnimator.SetTrigger(SendSignal);
                }
            }
        }
    }

    private bool IsNotObstructed()
    { 
        if (Physics.Linecast(RaycastStartingPosition.position, PlayerPosition.transform.position , out Hit))
        {
            Debug.Log(Hit.collider.gameObject.name);

            if (Hit.collider.tag == "Player")
            {
                return (true);
            }
        }

        return (false);
    }

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