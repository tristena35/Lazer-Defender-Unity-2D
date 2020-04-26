using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    // Delay time before loading Game Over
    [SerializeField] float delayInSeconds = 2f;

    //Cached Reference
    ThemeSong themeSong;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        // Pause song when in game
        themeSong = FindObjectOfType<ThemeSong>();
        themeSong.PauseStartMenuSong();

        Debug.Log("Load Game Scene");
        SceneManager.LoadScene(1);
        try
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
        catch (Exception e)
        {
            Debug.Log("Just started, no need to reset game");
        }
    }
    
    public void LoadGameOver()
    {
        Debug.Log("Load Game Over Scene");
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        // Play song when out of game
        themeSong = FindObjectOfType<ThemeSong>();
        themeSong.PlayStartMenuSong();

        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
