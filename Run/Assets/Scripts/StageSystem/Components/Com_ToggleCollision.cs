using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Com_ToggleCollision : MonoBehaviour, IInteractable
{
    private Collider ObjectCollider;

    private Renderer ObjectColor;

    [SerializeField] float Transparency;

    private bool IsPhasing;
    void Start()
    {
        IsPhasing = false;

        ObjectCollider = GetComponent<Collider>();

        ObjectColor = GetComponent<MeshRenderer>();

        Transparency = ObjectColor.material.color.a;
    }

    public void DoSomething(bool Activate)
    {
            if (Activate == true)
        {
            ObjectCollider.enabled = !ObjectCollider.enabled;

            StartCoroutine(FadeOut());
        }
        else
        {
            ObjectCollider.enabled = !ObjectCollider.enabled;

            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {
        IsPhasing = true;

        while (Transparency > 0.2f)
        {
            Transparency -= 0.1f;

            yield return new WaitForSeconds(0.1f);

            ObjectColor.material.color = new Color(ObjectColor.material.color.r, ObjectColor.material.color.g, ObjectColor.material.color.b, Transparency);
        }
    }

    IEnumerator FadeIn()
    {
        IsPhasing = false;

        while (Transparency < 1f)
        {
            Transparency += 0.1f;

            yield return new WaitForSeconds(0.1f);

            ObjectColor.material.color = new Color(ObjectColor.material.color.r, ObjectColor.material.color.g, ObjectColor.material.color.b, Transparency);
        }
    }
}
