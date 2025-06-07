using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Com_ToggleCollision : MonoBehaviour, IInteractable
{
    private Collider ObjectCollider;
    private Renderer ObjectColor;
    private float Transparency;
    private bool Active;
    [SerializeField] NormalOrInvert SetBehavior;

    private enum NormalOrInvert
    {
        Normal,

        Invert
    }

    void Start()
    {
        ObjectCollider = GetComponent<Collider>();

        ObjectColor = GetComponent<MeshRenderer>();

        Transparency = ObjectColor.material.color.a;

        if (SetBehavior == NormalOrInvert.Normal)
        {
            Active = false;

            ObjectCollider.enabled = true;
        }
        else
        {
            Active = true;
        }

        CheckBool();
    }

    public void DoSomething()
    {
        Active = !Active;
 
        CheckBool();
    }


    private void CheckBool()
    {
        if (Active == true)
        {
            StartCoroutine(FadeOut());

            ObjectCollider.enabled = false;
        }
        else
        {
            StartCoroutine(FadeIn());

            ObjectCollider.enabled = true;
        }
        
    }

    private IEnumerator FadeOut()
    {
        while (Transparency > 0.2f)
        {
            Transparency -= 0.1f;

            yield return new WaitForSeconds(0.1f);

            ObjectColor.material.color = new Color(ObjectColor.material.color.r, ObjectColor.material.color.g, ObjectColor.material.color.b, Transparency);

            Active = !Active;         
        }
    }

    private IEnumerator FadeIn()
    {
        while (Transparency < 1f)
        {
            Transparency += 0.1f;

            yield return new WaitForSeconds(0.1f);

            ObjectColor.material.color = new Color(ObjectColor.material.color.r, ObjectColor.material.color.g, ObjectColor.material.color.b, Transparency);

            Active = !Active;            
        }
    }
}
