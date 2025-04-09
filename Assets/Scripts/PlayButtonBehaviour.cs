using UnityEngine;

public class PlayButtonBehaviour : MonoBehaviour
{
    public void OnMouseDown()
    {
        GameController.Instance.RestartGame();
    }
}
