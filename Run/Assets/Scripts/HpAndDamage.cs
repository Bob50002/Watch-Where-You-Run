using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HpAndDamage : MonoBehaviour
{
    public int Health;

    [SerializeField] TextMeshProUGUI HealthDisplay;

    [SerializeField] Image RedScreen;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthDisplay.text = "HP: " + Health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Health -= 1;

            Color Alpha = RedScreen.color;

            Alpha.a = 0.3f;

            RedScreen.color = Alpha;

            Destroy(other.gameObject);    
        }
    }
}
