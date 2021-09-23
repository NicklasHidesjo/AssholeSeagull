using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float gameTimer = 0f;
    [SerializeField] float gameDuration = 60f;
    public int score = 0;
    bool isGameOver = false;
    SceneLoader sceneLoader;
    Plate plate;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        plate = FindObjectOfType<Plate>();
    }

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
            FinishSandwich(false);
        }
    }

    public void FinishSandwich(bool Finished)
    {
        foreach (var food in plate.SandwichPieces)
        {
            score += food.GetScore();
        }

        PlayerPrefs.SetInt("newHighscore", 0);
        PlayerPrefs.SetInt("currentScore", score);
        int highscore = PlayerPrefs.GetInt("highscore", 0);

        if(!Finished)
        {
            score -= 1;
            score = (int)Mathf.Clamp(score, 0, Mathf.Infinity);
        }

        if(score > highscore)
        {
            PlayerPrefs.SetInt("newHighscore", 1);
            PlayerPrefs.SetInt("highscore", score);
        }

        Debug.Log("Score: " + score);

        sceneLoader.LoadScene(0);
    }
}
