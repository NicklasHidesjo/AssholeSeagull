                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class MainMenuPointer : MonoBehaviour
{
    [SerializeField] SteamVR_LaserPointer laserPointer;
    SceneLoader sceneLoader;

    float volume;

    /// <summary>
    /// /SOUNDMANAGER
    /// </summary>
    public Slider slider = null;

    private void Start()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;

        sceneLoader = FindObjectOfType<SceneLoader>();
        LoadVolume();
    }
    void LoadVolume()
    {
        volume = PlayerPrefs.GetFloat("VolumeValue");
        if(slider == null)
        {
            return;
        }
        slider.value = volume;
    }
    void SaveVolume()
    {
        slider.value = volume;
        PlayerPrefs.SetFloat("VolumeValue", volume);
    }

    /// <summary>
    /// START GAME
    /// </summary>

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            sceneLoader.LoadScene("GameScene");
            Debug.Log("Cube was clicked");
        }

        else if (e.target.name == "Play")
        {
            sceneLoader.LoadScene("GameScene");
            Debug.Log("Button was clicked");
        }

        else if (e.target.name == "Decrease")
        {
            Debug.Log("sound -");
            volume -= 0.1f;
            volume = Mathf.Clamp(volume,0, 1f);
            SaveVolume();
        }

        else if (e.target.name == "Increase")
        {
            Debug.Log("sound +");
            volume += 0.1f;
            volume = Mathf.Clamp(volume, 0, 1f);
            SaveVolume();
        }

        else if(e.target.name == "Replay")
        {
            sceneLoader.LoadScene("GameScene");
        }    

        else if (e.target.name == "Quit")
        {
            sceneLoader.Quit();
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was exited");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was exited");
        }
    }

    private void OnDestroy()
    {
        laserPointer.PointerIn -= PointerInside;
        laserPointer.PointerOut -= PointerOutside;
        laserPointer.PointerClick -= PointerClick;
    }
}
