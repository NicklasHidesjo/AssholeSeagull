                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

public class MainMenuPointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

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
      //  LoadVolume();
    }

/*    public void SaveVolumeButton()
    {
        float volumeValue = slider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadVolume();
    }

    void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        slider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }*/

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
            SceneManager.LoadScene("GameScene");
            Debug.Log("Cube was clicked");
        }
        else if (e.target.name == "Button")
        {
            SceneManager.LoadScene("GameScene");
            Debug.Log("Button was clicked");
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
