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
    [SerializeField] private Transform digitsParent = null;
    [SerializeField] private int sortingOrder = 0;

    public void UpdateScore(int score)
    {
        ClearRenderers();
        string scoreStr = score.ToString();

        while(renderers.Count < scoreStr.Length)
        {
            GameObject digitObject = Instantiate(digitPrefab);
            digitObject.transform.position = new Vector3(startPosition.x - offset, startPosition.y, 0);
            digitObject.transform.localScale = new Vector3(digitScale, digitScale, digitScale);

            if (digitsParent != null)
            {
                digitObject.transform.SetParent(digitsParent);
            }

            SpriteRenderer spriteRenderer = digitObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = sortingOrder;
            }

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

    private void ClearRenderers()
    {
        foreach (GameObject digit in renderers)
        {
            Destroy(digit);
        }
        renderers.Clear();
        offset = 0f;
    }
}