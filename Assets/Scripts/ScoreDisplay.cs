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
    [SerializeField] private bool center = false;

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

        for (int i = scoreStr.Length - 1; i >= 0; i--)
        {
            renderers[i].GetComponent<SpriteRenderer>().sprite = digitSprites[scoreStr[scoreStr.Length - i - 1] - '0'];
        }

        if (center)
        {
            for (int i = scoreStr.Length - 1; i >= 0; i--)
            {
                float width = renderers[i].GetComponent<SpriteRenderer>().bounds.size.x;
                var t = renderers[i].transform;
                t.position = new Vector3(t.position.x + width / 2f + digitOffset / 2, t.position.y, t.position.z);
            }
        }
    }

    public void ClearRenderers()
    {
        renderers.Clear();
        foreach (GameObject digit in GameObject.FindGameObjectsWithTag("Digit"))
        {
            Destroy(digit);
        }
        offset = 0f;
    }
}