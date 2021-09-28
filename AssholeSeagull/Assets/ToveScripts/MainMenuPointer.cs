                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class MainMenuPointer : MonoBehaviour
{
    [SerializeField] SteamVR_LaserPointer rightHand;
    [SerializeField] SteamVR_LaserPointer leftHand;

    SceneLoader sceneLoader;
    AudioSource buttonPlayer;
    /// <summary>
    /// /SOUNDMANAGER
    /// </summary>

    private void Start()
    {
        rightHand.PointerIn += PointerInside;
        leftHand.PointerIn += PointerInside;
        rightHand.PointerOut += PointerOutside;
        leftHand.PointerOut += PointerOutside;
        rightHand.PointerClick += PointerClick;
        leftHand.PointerClick += PointerClick;

        buttonPlayer = FindObjectOfType<AudioSource>();

        sceneLoader = FindObjectOfType<SceneLoader>();

        Debug.Log("pointer name: " + rightHand.name);
    }

    /// <summary>
    /// START GAME
    /// </summary>

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            PlayButtonSound();
            sceneLoader.LoadScene("GameScene");
            Debug.Log("Cube was clicked");
        }

        else if (e.target.name == "Play")
        {
            PlayButtonSound();
            sceneLoader.LoadScene("GameScene");
            Debug.Log("Button was clicked");
        }

        else if(e.target.name == "Replay")
        {
            PlayButtonSound();
            sceneLoader.LoadScene("GameScene");
        }    

        else if (e.target.name == "Quit")
        {
            PlayButtonSound();
            sceneLoader.Quit();
        }

        else if(e.target.name == "Main Menu")
		{
            PlayButtonSound();
            sceneLoader.LoadScene(0);
		}

        else if(e.target.name == "Free Roam")
        {
            PlayButtonSound();
            sceneLoader.LoadScene("FreeRoamMode");
        }
    }

    public void PlayButtonSound()
    {
        buttonPlayer.Play();
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
        rightHand.PointerIn -= PointerInside;
        leftHand.PointerIn -= PointerInside;
        rightHand.PointerOut -= PointerOutside;
        leftHand.PointerOut -= PointerOutside;
        rightHand.PointerClick -= PointerClick;
        leftHand.PointerClick -= PointerClick;
    }
}
