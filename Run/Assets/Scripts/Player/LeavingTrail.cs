using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingTrail : MonoBehaviour
{
    [SerializeField] float OriginalCountdownValue;

    private float PlayerX;

    private float PlayerY;

    private float PlayerZ;
    
    [SerializeField] List<GameObject> ProjectilesPool = new List<GameObject>();

    void Start()
    {
        StartCoroutine(ReleaseProjectile());
    }

    IEnumerator ReleaseProjectile()
    {
      
          PlayerX = this.transform.position.x;

          PlayerY = this.transform.position.y;

          PlayerZ = this.transform.position.z;

          yield return new WaitForSeconds(0.3f);

          Instantiate(ProjectilesPool[0], new Vector3(PlayerX , PlayerY, PlayerZ), Quaternion.identity);

          StartCoroutine(ReleaseProjectile());
        
    }
}
