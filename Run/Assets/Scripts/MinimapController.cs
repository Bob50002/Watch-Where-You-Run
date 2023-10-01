using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapController : MonoBehaviour
{
    [SerializeField] RawImage Minimap;

    private float miniMapOriginalPosition;

    [SerializeField] Transform MinimapNewPosition;

    [SerializeField] float MoveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MoveToward = MoveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Minimap.transform.position = Vector3.MoveTowards(Minimap.transform.position, MinimapNewPosition.position, MoveToward);
        }
    }
}
