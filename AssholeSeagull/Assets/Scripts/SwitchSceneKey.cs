using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneKey : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("MAINSCENE");
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("GAMESCENE");
            SceneManager.LoadScene("GameScene");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("ENDSCENE");
            SceneManager.LoadScene("EndScene");
        }
    }
}
