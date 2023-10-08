using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingTrail : MonoBehaviour
{
    [SerializeField] float OriginalCountdownValue;

    private float PlayerX;

    private float PlayerY;

    private float PlayerZ;

    //private float Countdown;
    
    [SerializeField] List<GameObject> ProjectilesPool = new List<GameObject>();

    void Start()
    {
        //Countdown = OriginalCountdownValue;

        StartCoroutine(ReleaseProjectile());
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    IEnumerator ReleaseProjectile()
    {
      
          PlayerX = this.transform.position.x;

          PlayerY = this.transform.position.y;

          PlayerZ = this.transform.position.z;

          //Countdown = OriginalCountdownValue;

          yield return new WaitForSeconds(0.3f);

          Instantiate(ProjectilesPool[0], new Vector3(PlayerX , PlayerY, PlayerZ), Quaternion.identity);

          StartCoroutine(ReleaseProjectile());
        
    }
}
