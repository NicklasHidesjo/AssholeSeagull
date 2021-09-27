using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSingleton : MonoBehaviour
{
    public AudioSource seagullAudio;
    public AudioSource foodAudio;

    public void SeagullFx(AudioClip clip)
    {
        seagullAudio.clip = clip;
        seagullAudio.Play();
    }

    public void Seagull(AudioClip clip)
    {
        seagullAudio.clip = clip;
        seagullAudio.Play();
    }

    public void FoodSound(AudioClip clip)
    {
        seagullAudio.clip = clip;
        seagullAudio.Play();
    }
}
