using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    [SerializeField] HpAndDamage Health;
    [SerializeField] Respawn Respawn;

    void Update()
    {
        if (Health._Health <= 0)
        {
            Respawn.RestartStage();           
        }
    }
}
