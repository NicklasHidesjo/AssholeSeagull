using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        Debug.Log(inputDevices.Count);

        if(inputDevices.Count <= 0)
		{
            return;
		}

        Debug.Log("loading next scene");

        SceneManager.LoadScene(1);
    }
}
