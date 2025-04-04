using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipe"))
        {
            Destroy(other.gameObject);
        }
    }
}
