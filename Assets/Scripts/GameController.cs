using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public bool gameOver = true;
    public bool stopScrolling = false;
    public int score = 0;
    public int bestScore;
    private bool firstPlayPress = true;

    [SerializeField] private PhoebeController phoebe;
    [SerializeField] private PipeSpawner pipeSpawner;
    [SerializeField] private SpriteRenderer titleSpriteRenderer;
    [SerializeField] private Sprite gameOverSprite;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private ScoreDisplay scoreDisplay;
    [SerializeField] private ScoreDisplay medalScoreDisplay;
    [SerializeField] private ScoreDisplay medalBestScoreDisplay;
    [SerializeField] private SpriteRenderer medalDisplay;
    [SerializeField] private List<Sprite> medals = new();
    [SerializeField] private Vector3 phoebeStartPosition;

    void Awake()
    {
        Application.targetFrameRate = 60;
        bestScore = PlayerPrefs.GetInt("best_score", 0);
        medalBestScoreDisplay.UpdateScore(bestScore);
        UpdateMedal();
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("best_score", bestScore);
        PlayerPrefs.Save();
    }

    public void RestartGame()
    {
        stopScrolling = false;
        gameOver = false;
        score = 0;
        scoreDisplay.UpdateScore(0);
        menu.SetActive(false);

        if (firstPlayPress)
        {
            titleSpriteRenderer.sprite = gameOverSprite;
            gameOverDisplay.SetActive(true);
            firstPlayPress = false;
        }
        else
        {
            phoebe.transform.position = phoebeStartPosition;

            foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe"))
            {
                Destroy(pipe);
            }
        }

        phoebe.Revive();
        pipeSpawner.RestartSpawning();
    }

    public void GameOver()
    {
        gameOver = true;
        pipeSpawner.StopSpawning();
        medalScoreDisplay.UpdateScore(score);
        if(score > bestScore)
        {
            bestScore = score;
            medalBestScoreDisplay.UpdateScore(bestScore);
            UpdateMedal();
        }
        menu.SetActive(true);
    }

    public void AddScore(int n)
    {
        score += n;
        scoreDisplay.UpdateScore(score);
    }

    private void UpdateMedal()
    {
        if (bestScore >= 100)
        {
            medalDisplay.sprite = medals[1];
        } else if(bestScore >= 50)
        {
            medalDisplay.sprite = medals[0];
        }
    }
    
}
