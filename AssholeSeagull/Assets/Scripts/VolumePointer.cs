using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

public class VolumePointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    [SerializeField] bool increase;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if(increase)
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
        }
        else
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
