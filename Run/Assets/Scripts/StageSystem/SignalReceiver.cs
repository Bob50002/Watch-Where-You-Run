using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    [SerializeField] Camera FirstPersonCamera;

    [SerializeField] List<GameObject> LinkedComponent = new List<GameObject>();

    [SerializeField] Color LineColor;

    private bool Enable;


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
        if (IsVisible(FirstPersonCamera, this.gameObject))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Enable == true)
                {
                    foreach (var Components in LinkedComponent)
                    {
                        Components.GetComponent<IInteractable>().DoSomething(true);           
                    }

                    Enable = !Enable;
                }
                else
                {
                    foreach (var Components in LinkedComponent)
                    {
                        Components.GetComponent<IInteractable>().DoSomething(false);
                    }

                    Enable = !Enable;
                }
             
            }
        }
    }

    private void OnDrawGizmos()
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