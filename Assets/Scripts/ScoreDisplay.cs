using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private float offset = 0f;
    private List<GameObject> renderers = new();
    [SerializeField] private List<Sprite> digitSprites = new();
    [SerializeField] private GameObject digitPrefab;
    [SerializeField] private Vector2 startPosition = new(1f, -1f);
    [SerializeField] private float digitOffset = 0.1f;
    [SerializeField] private float digitScale = 0.6f;

    public void UpdateScore(int score)
    {
        string scoreStr = score.ToString();

        while(renderers.Count < scoreStr.Length)
        {
            GameObject digitObject = Instantiate(digitPrefab);
            digitObject.transform.position = new Vector3(startPosition.x - offset, startPosition.y, 0);
            digitObject.transform.localScale = new Vector3(digitScale, digitScale, digitScale);
            renderers.Add(digitObject);
            offset += digitOffset;
        }

        for (int i = 0; i < scoreStr.Length; i++)
        {
            renderers[i].GetComponent<SpriteRenderer>().sprite = digitSprites[scoreStr[i] - '0'];
        }

        for (int i = scoreStr.Length; i < renderers.Count; i++)
        {
            renderers[i].SetActive(false);
        }
    }
}
