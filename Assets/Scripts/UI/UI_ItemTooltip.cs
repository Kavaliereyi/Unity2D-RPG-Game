using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemTooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private int defaultFontSize = 34;

    public void ShowTooltip(ItemData_Equipment item)
    {
        if(item == null)
            return;

        itemNameText.text = item.itemName;
        itemTypeText.text = item.equipmentType.ToString();
        itemDescription.text = item.GetDescription();


        if (itemNameText.text.Length > 23)
            itemNameText.fontSize = itemNameText.fontSize * .7f;
        else
            itemNameText.fontSize = defaultFontSize;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        itemNameText.fontSize = defaultFontSize;
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
            pivotX > 0.7f ? 1.1f : 0,
            pivotY < 0.3f ? 0 : 1.1f
        );

        transform.position = newPosition;
    }

}
