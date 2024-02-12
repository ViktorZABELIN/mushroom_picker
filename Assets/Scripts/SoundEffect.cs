using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;


    public void OnMusic()
    {
        PlayEffect();
    }

    public void OffMusic()
    {

    }
    public void PlayEffect()
    {
        _audioSource.Play();
    }

}
