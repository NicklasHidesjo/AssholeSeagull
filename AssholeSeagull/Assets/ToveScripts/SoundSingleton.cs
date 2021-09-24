using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSingleton : MonoBehaviour
{
    public AudioSource seagullAudio;
    public AudioSource foodAudio;

    private void Awake()
    {
        seagullAudio.volume = PlayerPrefs.GetFloat("VolumeValue", 0.5f);
        foodAudio.volume = PlayerPrefs.GetFloat("VolumeValue", 0.5f);
    }

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
