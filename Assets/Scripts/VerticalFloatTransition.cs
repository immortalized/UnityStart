using UnityEngine;

public class VerticalFloatTransition : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float offset = 5f;

    private Vector3 originalPosition;
    private Vector3 offScreenPosition;
    private bool hasStartedFloating = false;

    void Awake()
    {
        originalPosition = transform.position;
        offScreenPosition = new Vector3(
            originalPosition.x,
            originalPosition.y + offset,
            originalPosition.z
        );
    }

    void Update()
    {
        if (GameController.Instance.gameOver && !hasStartedFloating)
        {
            hasStartedFloating = true;
        }
        else if (!GameController.Instance.gameOver)
        {
            hasStartedFloating = false;
        }

        if (hasStartedFloating)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * speed);
        }
    }

    public void TranslateToOriginal()
    {
        transform.position = originalPosition;
    }

    public void TranslateToOffset()
    {
        transform.position = offScreenPosition;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
