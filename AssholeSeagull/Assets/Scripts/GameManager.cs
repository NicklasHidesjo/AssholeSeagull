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

    public void CollectScore(FoodItem[] sandwich)
    {
        foreach (var food in sandwich)
        {
            score++;
        }

        Debug.Log("Score: " + score);
    }
}
