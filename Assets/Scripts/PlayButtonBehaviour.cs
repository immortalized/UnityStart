using UnityEngine;

public class PlayButtonBehaviour : MonoBehaviour
{
    [SerializeField] private PhoebeController phoebe;
    [SerializeField] private SpriteRenderer titleSpriteRenderer;
    [SerializeField] private Sprite gameOverSprite;
    [SerializeField] private GameObject menu;
    [SerializeField] private Vector3 phoebeStartPosition;
    private bool firstPress = true;

    public void OnMouseDown()
    {
        HideMenu();

        if(firstPress){
            titleSpriteRenderer.sprite = gameOverSprite;
            firstPress = false;
        } else{
            phoebe.transform.position = phoebeStartPosition;

            foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe"))
            {
                Destroy(pipe);
            }
        }

        phoebe.Revive();
    }

    public void ShowMenu(){
        menu.SetActive(true);
    }

    public void HideMenu(){
        menu.SetActive(false);
    }
}
