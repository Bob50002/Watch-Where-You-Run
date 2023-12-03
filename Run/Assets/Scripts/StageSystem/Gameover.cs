using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    [SerializeField] HpAndDamage Health;

    void Update()
    {
        if (Health._Health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
