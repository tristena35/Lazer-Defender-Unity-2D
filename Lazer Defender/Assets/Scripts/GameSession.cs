using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    // UI
    int score = 0;
    int health = 500;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHealth()
    {
        return health;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void DeductHealth(int projectileDamage)
    {
        health -= projectileDamage;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}
