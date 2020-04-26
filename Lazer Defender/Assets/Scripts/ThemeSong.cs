using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSong : MonoBehaviour
{

    [SerializeField] AudioSource mainTheme;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // If there is already a music object for the main theme, do not start a new one
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PauseStartMenuSong()
    {
        mainTheme.Pause();
        Debug.Log("Paused");
    }

    public void PlayStartMenuSong()
    {
        mainTheme.Play();
        Debug.Log("Play");
    }
    
}
