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

    public int _Health
    {
        get { return Health; }

        private set
        {
            Health = value;
        }
    }



    void Start()
    {
        RespawnPosition = this.transform.position;

        _Health = Health;
    }

    void Update()
    {
        HealthDisplay.text = "HP: " + Health.ToString();
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

                StartCoroutine(RedScreenWhenHit());

                Destroy(other.gameObject);



                //RedScreen.color = Alpha;
            }
        }
     
    }

    private IEnumerator RedScreenWhenHit()
    {
        //this.gameObject.transform.position = respawnPosition;

        yield return new WaitForSeconds(1f);
    }
}
