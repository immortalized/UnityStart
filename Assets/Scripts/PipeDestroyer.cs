using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.CompareTag("Pipe"))
        {
            Destroy(other.gameObject);
        }
    }
}
