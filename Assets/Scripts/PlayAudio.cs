using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioSource source;

    public void PlaySource()
    {
        source.Play();
    }
}
