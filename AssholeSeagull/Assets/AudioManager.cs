using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Valve.VR.Extras;

public class AudioManager : MonoBehaviour
{
    [SerializeField] SteamVR_LaserPointer rightHand;
    [SerializeField] SteamVR_LaserPointer leftHand;

    [SerializeField] Slider masterSlider = null;
    [SerializeField] Slider musicSlider = null;
    [SerializeField] Slider effectsSlider = null;

    [SerializeField] AudioMixer mixer;

    float masterVolume;
    float musicVolume;
    float effectsVolume;

    private void Start()
    {
        rightHand.PointerClick += PointerClick;
        leftHand.PointerClick += PointerClick;

        LoadVolume();
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Decrease Master")
        {
            Debug.Log("sound -");
            masterVolume -= 0.1f;
            masterVolume = Mathf.Clamp(masterVolume, 0, 1f);
            SaveVolume();
        }
        else if (e.target.name == "Increase Master")
        {
            Debug.Log("sound +");
            masterVolume += 0.1f;
            masterVolume = Mathf.Clamp(masterVolume, 0, 1f);
            SaveVolume();
        }
        if (e.target.name == "Decrease Music")
        {
            musicVolume -= 0.1f;
            musicVolume = Mathf.Clamp(musicVolume, 0, 1f);
            SaveVolume();
        }
        else if (e.target.name == "Increase Music")
		{
            musicVolume += 0.1f;
            musicVolume = Mathf.Clamp(musicVolume, 0, 1f);
            SaveVolume();
        }

        if (e.target.name == "Decrease Effects")
        {
            effectsVolume -= 0.1f;
            effectsVolume = Mathf.Clamp(effectsVolume, 0, 1f);
            SaveVolume();
        }
        else if (e.target.name == "Increase Effects")
		{
            effectsVolume += 0.1f;
            effectsVolume = Mathf.Clamp(effectsVolume, 0, 1f);
            SaveVolume();
        }
    }

    void LoadVolume()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);

        masterSlider.value = masterVolume;
        SetVolume("Master", masterVolume);
        musicSlider.value = musicVolume;
        SetVolume("Music", musicVolume);
        effectsSlider.value = effectsVolume;
        SetVolume("Effects", effectsVolume);
    }
    void SaveVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("EffectsVolume", effectsVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        masterSlider.value = masterVolume;
        SetVolume("Master", masterVolume);
        musicSlider.value = musicVolume;
        SetVolume("Music", musicVolume);
        effectsSlider.value = effectsVolume;
        SetVolume("Effects", effectsVolume);
    }

    public void SetVolume(string volume , float value)
	{
		mixer.SetFloat(volume, Mathf.Log10(value) * 20);
	}

    private void OnDestroy()
    {
        rightHand.PointerClick -= PointerClick;
        leftHand.PointerClick -= PointerClick;
    }
}
