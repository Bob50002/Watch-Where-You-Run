using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    [SerializeField] HpAndDamage _Health;

    void Update()
    {
        if (_Health._Health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
