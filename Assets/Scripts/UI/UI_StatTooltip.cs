using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_StatTooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;

    public void ShowStatTooltip(string _text)
    {
        description.text = _text;
        gameObject.SetActive(true);
    }

    public void HideStatTooltip()
    {
        description.text = "";
        gameObject.SetActive(false);
    }

    public void SetPosition(Vector2 mousePosition)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 offset = new Vector2(30, -30);


        Vector2 newPosition = mousePosition + offset;


        float pivotX = (newPosition.x / Screen.width);
        float pivotY = (newPosition.y / Screen.height);


        rectTransform.pivot = new Vector2(
            pivotX > 0.7f ? 1 : 0,
            pivotY < 0.3f ? 0 : 1
        );

        transform.position = newPosition;
    }
}
