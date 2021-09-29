using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeRoamEndScreen : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highscoreText;

    [SerializeField] AudioClip noNewRecordSound;
    [SerializeField] AudioSource noNewRecordPlayer;
    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("currentFreeRoamScore").ToString();
        highscoreText.text = PlayerPrefs.GetInt("freeRoamHighscore").ToString();

        if (PlayerPrefs.GetInt("newHighscore") == 1)
        {
            FindObjectOfType<NewHighScoreHandler>().NewHighScoreCelebration();
        }
        else
        {
            noNewRecordPlayer.clip = noNewRecordSound;
            noNewRecordPlayer.Play();
        }
    }
}
