using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float gameTimer = 0f;
    [SerializeField] float gameDuration = 60f;
    public int score = 0;
    bool isGameOver = false;

    private void Update()
    {
        if(isGameOver)
        {
            return;
        }

        gameTimer += Time.deltaTime;

        if(gameTimer > gameDuration)
        {
            Debug.Log("Time Over!");
            isGameOver = true;
        }
    }

    public void CollectScore(List<FoodItem> sandwich)
    {
        foreach (var food in sandwich)
        {
            score++;
        }

        PlayerPrefs.SetInt("newHighscore", 0);
        PlayerPrefs.SetInt("currentScore", score);
        int highscore = PlayerPrefs.GetInt("highscore", 0);

        if(score > highscore)
        {
            PlayerPrefs.SetInt("newHighscore", 1);
            PlayerPrefs.SetInt("highscore", score);
        }

        Debug.Log("Score: " + score);
    }
}
