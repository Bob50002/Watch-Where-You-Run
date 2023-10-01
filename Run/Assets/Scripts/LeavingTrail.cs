using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingTrail : MonoBehaviour
{
    [SerializeField] List<GameObject> ProjectilesPool = new List<GameObject>();

    [SerializeField] float OriginalCountdownValue;

    private float PlayerX;

    private float PlayerY;

    private float PlayerZ;

    private float Countdown;
    void Start()
    {
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
          PlayerX = this.transform.position.x;

          PlayerY = this.transform.position.y;

          PlayerZ = this.transform.position.z;

          Countdown = OriginalCountdownValue;

          yield return new WaitForSeconds(0.3f);

          Instantiate(ProjectilesPool[0], new Vector3(PlayerX , PlayerY, PlayerZ), Quaternion.identity);      
        }
    }
}
