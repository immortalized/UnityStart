using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float minHeight = -0.6f;
    [SerializeField] private float maxHeight = 0.6f;
    [SerializeField] private float spawnX = 5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 0f, spawnDelay);
        StopSpawning();
    }

    void SpawnPipe()
    {
        Vector3 spawnPos = new Vector3(spawnX, Random.Range(minHeight, maxHeight), 0);
        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }

    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnPipe));
    }

    public void RestartSpawning()
    {
        if (!IsInvoking(nameof(SpawnPipe)))
        {
            InvokeRepeating(nameof(SpawnPipe), 0f, spawnDelay);
        }
    }
}
