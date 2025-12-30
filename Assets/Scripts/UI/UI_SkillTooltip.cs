using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_SkillTooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skillText;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI skillPrice;

    public void ShowTooltip(string _skillDescription, string _skillName, int _skillPrice)
    {
        skillName.text = _skillName;
        skillText.text = _skillDescription;
        skillPrice.text = "Cost: " + _skillPrice.ToString();

        gameObject.SetActive(true);
    }

    public void HideTooltip() => gameObject.SetActive(false);
}

