using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResizeAutomatically : MonoBehaviour
{
    private float width, height;

    // Use this for initialization
    void Update()
    {
        width = this.gameObject.GetComponent<RectTransform>().rect.width;
        height = this.gameObject.GetComponent<RectTransform>().rect.height;
        Vector2 newSize = new Vector2(width / 3, height / 3);
        this.gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;
    }

}
