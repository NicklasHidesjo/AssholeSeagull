using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSingleton : MonoBehaviour
{
    public AudioSource seagullAudio;
    public AudioSource foodAudio;

    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    public static SoundSingleton Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
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
