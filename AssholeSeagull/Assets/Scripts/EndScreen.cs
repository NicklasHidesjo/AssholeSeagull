using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highscoreText;

    [SerializeField] AudioClip noNewRecordSound;
    [SerializeField] AudioSource noNewRecordPlayer;
    void Start()
    {
        if(PlayerPrefs.GetInt("newHighscore") == 1)
        {
            FindObjectOfType<NewHighScoreHandler>().NewHighScoreCelebration();
            scoreText.text = PlayerPrefs.GetInt("currentScore").ToString();
            highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        }
        else
        {
            scoreText.text = PlayerPrefs.GetInt("currentScore").ToString();
            highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
            noNewRecordPlayer.clip = noNewRecordSound;
            noNewRecordPlayer.Play();
        }
    }
}
