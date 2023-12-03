using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    [SerializeField] AudioSource Audio;

   public void PlayTestAudio()
    {
        Audio.Play();
    }
}
