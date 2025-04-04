using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float minHeight = -0.6f;
    [SerializeField] private float maxHeight = 0.6f;
    [SerializeField] private float spawnX = 5f;

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
