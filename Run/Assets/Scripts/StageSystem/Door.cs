using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //[SerializeField] GameObject Player;

    [SerializeField] Camera FirstPersonCamera;

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
        var Renderer = this.GetComponent<Renderer>();

        if (IsVisible(FirstPersonCamera, this.gameObject))
        {
            Renderer.material.SetColor("_Color", Color.green);

            Debug.Log("You seee me");
        }
        else
        {
            Renderer.material.SetColor("_Color", Color.red);
        }
    }

}
