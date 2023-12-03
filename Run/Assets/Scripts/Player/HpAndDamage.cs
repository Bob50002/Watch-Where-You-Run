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
    [SerializeField] AudioSource Audio;
    [SerializeField] AudioClip DamagedAudio;

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

                StartCoroutine(RedScreenWhenHit());

                Destroy(other.gameObject);

                Audio.PlayOneShot(DamagedAudio);
            }
        }
     
    }

    private IEnumerator RedScreenWhenHit()
    {
        Color Alpha = RedScreen.color;

        Alpha.a = 0.5f;
   
        while (Alpha.a > 0)
        {
            Alpha.a -= 0.1f;

            yield return new WaitForSeconds(0.1f);

            RedScreen.color = Alpha;
        }
    }
}
