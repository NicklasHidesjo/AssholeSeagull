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
    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }
    /// <summary>
    /// /SOUNDMANAGER
    /// </summary>
    public Slider slider = null;

    private void Start()
    {
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

/*    public void MinusVolumeClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("sound -");
            AudioListener.volume -= 0.1f;
        }
        else if (e.target.name == "-")
        {
            Debug.Log("sound -");
            AudioListener.volume -= 0.1f;
        }
    }

    public void PlusVolumeClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("sound +");
            AudioListener.volume += 0.1f;
        }
        else if (e.target.name == "+")
        {
            Debug.Log("sound +");
            AudioListener.volume += 0.1f;
        }
    }*/

    public void SaveButtonClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
        //    SaveVolumeButton();
        }
        else if (e.target.name == "Save")
        {
          // SaveVolumeButton();
        }
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
}
