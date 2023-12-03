using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiver : MonoBehaviour 
{
    [Header("Components")]
    [SerializeField] List<GameObject> LinkedComponent = new List<GameObject>();
    [SerializeField] Color LineColor; 

    [Header("Animation")]
    [SerializeField] Animator MCAnimator;
    private const string SendSignal = "SendSignal";

    
    [Header("Linecast and activation")]
    [SerializeField] float Range;
    [SerializeField] LayerMask Mask;
    [SerializeField] Transform RaycastStartingPosition;
    [SerializeField] GameObject PlayerPosition;
    [SerializeField] Camera FirstPersonCamera; 
    RaycastHit Hit;
    [SerializeField] float CountdownTimer;
    private bool ReadyToActivate;
    private const string Player = "Player";

    [Header("Audio")]
    [SerializeField] AudioSource Audio;
    [SerializeField] AudioClip SendSignalAudio;

    private bool IsVisible(Camera C, GameObject PlayerCharacter)
    {
        var Planes = GeometryUtility.CalculateFrustumPlanes(C);

        var Point = PlayerCharacter.transform.position;

        foreach (var Plane in Planes)
        {
            if (Plane.GetDistanceToPoint(Point) < 0)
            {
                return false;
            }
        }

        return true;
    }

    private void Start()
    {
        ReadyToActivate = true;
    }

    private void Update()
    {
        if (IsVisible(FirstPersonCamera, this.gameObject))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && IsNotObstructed() && ReadyToActivate == true)
            {
                ReadyToActivate = false;

                foreach (var Components in LinkedComponent)
                {
                    Components.GetComponent<IInteractable>().DoSomething();

                    StartCoroutine(Countdown());

                    MCAnimator.SetTrigger(SendSignal);

                    Audio.PlayOneShot(SendSignalAudio);
                }
            }
        }
    }

    private bool IsNotObstructed()
    { 
        if (Physics.Linecast(RaycastStartingPosition.position, PlayerPosition.transform.position , out Hit))
        {
            Debug.Log(Hit.collider.gameObject.name);

            if (Hit.collider.tag == Player)
            {
                return (true);
            }
        }

        return (false);
    }

    private void OnDrawGizmosSelected()
    {
        if (LinkedComponent != null)
        {
            Gizmos.color = LineColor;

            for (int i = 0; i < LinkedComponent.Count; i++)
            {
                Gizmos.DrawLine(this.transform.position, LinkedComponent[i].transform.position);
            }
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(CountdownTimer);

        ReadyToActivate = true;
    }
}