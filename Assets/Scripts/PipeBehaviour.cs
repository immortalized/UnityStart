using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;

    void Update()
    {
        if (GameController.Instance.gameOver || GameController.Instance.stopScrolling)
            return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x < -1)
        {
            Destroy(gameObject);
        }
    }
}
