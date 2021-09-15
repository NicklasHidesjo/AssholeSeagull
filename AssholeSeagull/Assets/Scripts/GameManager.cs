using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTimer = 0f;
    public int score = 0;
    public bool isGameOver = false;

    private void Update()
    {
        gameTimer += Time.deltaTime;

        if(gameTimer > 10f && isGameOver == false)
        {
            Debug.Log("FINISH");
            isGameOver = true;
        }
    }
}
