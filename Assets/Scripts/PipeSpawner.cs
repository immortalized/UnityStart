using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float minHeight = -0.6f;
    public float maxHeight = 0.6f;
    public float spawnX = 5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 0f, spawnRate);
    }

    void SpawnPipe()
    {
        if(GameState.gameOver)
            return;

        float randomY = Random.Range(minHeight, maxHeight);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
