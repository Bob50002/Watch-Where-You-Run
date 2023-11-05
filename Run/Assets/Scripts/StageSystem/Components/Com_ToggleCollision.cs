using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Com_ToggleCollision : MonoBehaviour, IInteractable
{
    private Collider ObjectCollider;

    private Renderer ObjectColor;

    [SerializeField] float Transparency;


    void Start()
    {
        ObjectCollider = GetComponent<Collider>();

        ObjectColor = GetComponent<MeshRenderer>();
    }

    public void DoSomething(bool Activate)
    {
            if (Activate == true)
        {
            ObjectCollider.enabled = !ObjectCollider.enabled;

            Transparency = ObjectColor.material.color.a;

            Transparency = 0.3f;

            //ObjectColor.material.color = new Color(null ,  , Transparency);
        }
        else
        {
            ObjectCollider.enabled = !ObjectCollider.enabled;
        }
    }
}
