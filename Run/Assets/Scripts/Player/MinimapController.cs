using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapController : MonoBehaviour
{
    [SerializeField] RawImage Minimap;

    private Vector3 MiniMapOriginalPosition;

    [SerializeField] Transform MinimapNewPosition;

    [SerializeField] float MoveSpeed;

    private bool MinimapEnable;
    void Start()
    {
        MinimapEnable = false;

        MiniMapOriginalPosition = Minimap.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            MinimapEnable = !MinimapEnable;
        }

        if (MinimapEnable == true)
        {
            Minimap.transform.position = Vector3.MoveTowards(Minimap.transform.position, MinimapNewPosition.position, MoveSpeed);
        }

        if (MinimapEnable == false)
        {
            Minimap.transform.position = Vector3.MoveTowards(Minimap.transform.position, MiniMapOriginalPosition, MoveSpeed);
        }
    }
}
