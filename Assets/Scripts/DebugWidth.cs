using UnityEngine;

public class DebugWidth : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<SpriteRenderer>().bounds.size.x);
    }
}
