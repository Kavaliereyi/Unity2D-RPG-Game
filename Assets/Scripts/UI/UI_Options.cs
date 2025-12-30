using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Options : MonoBehaviour
{
    [SerializeField] private GameObject saveExitButton;

    private void Start()
    {
        saveExitButton.GetComponent<Button>().onClick.AddListener(SaveAndExitButton);
    }

    private void SaveAndExitButton()
    {
        SaveManager.instance.SaveGame();
        Application.Quit();
    }
}
