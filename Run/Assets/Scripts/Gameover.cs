using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    [SerializeField] HpAndDamage HP;

    void Update()
    {
        if (HP.GetHealth() <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
