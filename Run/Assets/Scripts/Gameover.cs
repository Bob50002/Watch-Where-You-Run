using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    [SerializeField] HpAndDamage Hp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp.Health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
