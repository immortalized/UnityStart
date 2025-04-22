using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float minHeight = -0.6f;
    [SerializeField] private float maxHeight = 0.6f;
    [SerializeField] private float spawnX = 5f;
    [SerializeField] private float movingChance = 0.3f;
    [SerializeField] private float verticalAmplitude = 0.12f;
    [SerializeField] private float verticalFrequency = 0.45f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 0f, spawnDelay);
        StopSpawning();
    }

    void SpawnPipe()
    {
        float yPos = Random.Range(minHeight, maxHeight);
        Vector3 spawnPos = new Vector3(spawnX, yPos, 0);
        GameObject newPipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);

        PipeBehaviour pipeBehaviour = newPipe.GetComponent<PipeBehaviour>();
        if (pipeBehaviour != null && yPos >= maxHeight + minHeight && Random.Range(0f, 1f) <= movingChance)
        {
            pipeBehaviour.isMoving = true;
            pipeBehaviour.verticalAmplitude = verticalAmplitude;
            pipeBehaviour.verticalFrequency = verticalFrequency;
            //Debug.Log("move");
        } else{
            //Debug.Log("nomove");
            pipeBehaviour.isMoving = false;
        }
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
