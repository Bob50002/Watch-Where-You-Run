using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingTrail : MonoBehaviour
{
    [SerializeField] List<GameObject> ProjectilesPool = new List<GameObject>();

    private bool ProjectileReady;

    [SerializeField] float OriginalCountdownValue;

    private float Countdown;
    void Start()
    {
        ProjectileReady = false;

        Countdown = OriginalCountdownValue;
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine("ReleaseProjectile");

        Countdown = Mathf.MoveTowards(Countdown, 0, 0.5f * Time.deltaTime);


    }

    IEnumerator ReleaseProjectile()
    {
        if (Countdown == 0)
        {
            Instantiate(ProjectilesPool[0], new Vector3(this.transform.position.x, 2, this.transform.position.z), Quaternion.identity);

            Countdown = OriginalCountdownValue;
        }

        return null;
    }
}
