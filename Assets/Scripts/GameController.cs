using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public bool gameOver = true;
    public int score = 0;
    private bool firstPlayPress = true;

    [SerializeField] private PhoebeController phoebe;
    [SerializeField] private PipeSpawner pipeSpawner;
    [SerializeField] private SpriteRenderer titleSpriteRenderer;
    [SerializeField] private Sprite gameOverSprite;
    [SerializeField] private GameObject menu;
    [SerializeField] private ScoreDisplay scoreDisplay;
    [SerializeField] private ScoreDisplay bestScoreDisplay;
    [SerializeField] private Vector3 phoebeStartPosition;

    void Awake()
    {
        Application.targetFrameRate = 60;
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

    public void RestartGame()
    {
        gameOver = false;
        score = 0;
        scoreDisplay.ClearRenderers();
        scoreDisplay.UpdateScore(0);
        bestScoreDisplay.UpdateScore(111);
        menu.SetActive(false);

        if (firstPlayPress)
        {
            titleSpriteRenderer.sprite = gameOverSprite;
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
        phoebe.Die();
        menu.SetActive(true);
    }

    public void AddScore(int n)
    {
        score += n;
        scoreDisplay.UpdateScore(score);
    }
    
}
