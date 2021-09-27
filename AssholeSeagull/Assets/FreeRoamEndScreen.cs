using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeRoamEndScreen : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highscoreText;
    void Start()
    {
        if (PlayerPrefs.GetInt("newHighscore") == 1)
        {
            //L�gg in NEW RECORD
            Debug.Log("New Record");
            //Ta bort sen
            scoreText.text = PlayerPrefs.GetInt("currentFreeRoamScore").ToString();
            highscoreText.text = PlayerPrefs.GetInt("freeRoamHighscore").ToString();
        }
        else
        {
            scoreText.text = PlayerPrefs.GetInt("currentFreeRoamScore").ToString();
            highscoreText.text = PlayerPrefs.GetInt("freeRoamHighscore").ToString();
        }
    }
}
