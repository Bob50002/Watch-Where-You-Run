using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveMarker : MonoBehaviour
{
    [SerializeField] Camera MainCamera;

    [SerializeField] Image Waypoint;

    [SerializeField] float DistanceIndicator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Waypoint.transform.rotation = MainCamera.transform.rotation;
    }
}
