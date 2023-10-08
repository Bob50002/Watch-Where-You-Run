using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HpAndDamage : MonoBehaviour
{
    [SerializeField] int Health;

    [SerializeField] List<string> ProjectileList = new List<string>();

    [SerializeField] TextMeshProUGUI HealthDisplay;

    [SerializeField] Image RedScreen;

    private Vector3 RespawnPosition;

    public int _PlayerHealth
    {
        get
        {
            return Health;
        }
        set
        {
            Health = value;
        }
    }

    public int GetHealth()
    {
        return this._PlayerHealth;
    }


    void Start()
    {
        RespawnPosition = this.transform.position;
    }

    void Update()
    {
        HealthDisplay.text = "HP: " + GetHealth().ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < ProjectileList.Count; i++)
        {
            if (other.gameObject.CompareTag(ProjectileList[i].ToString()))
            {
                Health -= 1;

                Color Alpha = RedScreen.color;

                Alpha.a = 0.3f;

                RedScreen.color = Alpha;

                //StartCoroutine(Respawn());

                Destroy(other.gameObject);    
            }
        }
     
    }

    //IEnumerator Respawn()
    //{
    //    this.gameObject.transform.position = respawnPosition;

    //    yield return new WaitForSeconds(1f);
    //}
}
