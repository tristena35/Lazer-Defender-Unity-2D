using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;

    // Cached Reference
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
