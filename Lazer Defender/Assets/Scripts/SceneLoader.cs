/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadGame()
    {
        // Getting the currently active scene, find its buildIndex
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

        //SceneManager.LoadScene("Game"); - Inefficient way of doing this
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<ThemeSong>().ResetSong();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}*/
