using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour, ISaveManager
{
    [SerializeField] private UI_FadeScreen fadeScreen;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject restartButton;
    [Space]

    [SerializeField] private GameObject characterUI;
    [SerializeField] private GameObject skillTreeUI;
    [SerializeField] private GameObject craftUI;
    [SerializeField] private GameObject optionUI;
    [SerializeField] private GameObject inGameUI;


    [SerializeField] private GameObject itemTooltipPrefab;
    [SerializeField] private GameObject statTooltipPrefab;

    public UI_ItemTooltip currentItemTooltip;
    public UI_StatTooltip currentStatTooltip;
    public UI_CraftWindow craftWindow;
    public UI_SkillTooltip skillTooltip;

    [SerializeField] private UI_VolumeSlider[] volumeSettings;

    private void Awake()
    {
        //SwitchTo(skillTreeUI); // Need this to assign events on skill tree slots
        skillTreeUI.gameObject.SetActive(true);
        fadeScreen.gameObject.SetActive(true);
    }

    void Start()
    {
        GameObject itemTooltip = Instantiate(itemTooltipPrefab);
        itemTooltip.transform.SetParent(characterUI.transform, false);
        currentItemTooltip = itemTooltip.GetComponent<UI_ItemTooltip>();
        currentItemTooltip.HideTooltip();

        GameObject statTooltip = Instantiate(statTooltipPrefab);
        statTooltip.transform.SetParent(characterUI.transform, false);
        statTooltip.transform.localPosition += new Vector3(400, 0);
        currentStatTooltip = statTooltip.GetComponent<UI_StatTooltip>();
        currentStatTooltip.HideStatTooltip();
        SwitchTo(inGameUI);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchWithKeyTo(characterUI);
            AudioManager.instance.PlaySFX(8);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchWithKeyTo(craftUI);
            AudioManager.instance.PlaySFX(8);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SwitchWithKeyTo(skillTreeUI);
            AudioManager.instance.PlaySFX(8);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchWithKeyTo(optionUI);
            AudioManager.instance.PlaySFX(8);
        }
    }

    public void SwitchTo(GameObject _menu)
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            bool isFadeScreen = transform.GetChild(i).GetComponent<UI_FadeScreen>() != null;
            if (!isFadeScreen)
                transform.GetChild(i).gameObject.SetActive(false);
        }

        if (_menu != null)
        {
            _menu.SetActive(true);
            AudioManager.instance.PlaySFX(8);
        }

        if (GameManager.instance != null)
        {
            if (_menu == inGameUI)
                GameManager.instance.PauseGame(false);
            else
                GameManager.instance.PauseGame(true);
        }
    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if (_menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            CheckForInGameUI();
            return;
        }

        SwitchTo(_menu);
    }

    private void CheckForInGameUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf && transform.GetChild(i).GetComponent<UI_FadeScreen>() == null)
                return;
        }

        SwitchTo(inGameUI);
    }

    public void SwitchOnEndScreen()
    {
        fadeScreen.FadeOut();
        StartCoroutine(EndScreenCoroutine());
    }

    IEnumerator EndScreenCoroutine()
    {
        yield return new WaitForSeconds(1);
        endText.SetActive(true);
        yield return new WaitForSeconds(1);
        restartButton.SetActive(true);
    }

    public void RestartGameButton() => GameManager.instance.RestartScene();

    public void LoadData(GameData _data)
    {
        foreach (KeyValuePair<string, float> pair in _data.volumeSettings)
        {
            foreach (UI_VolumeSlider item in volumeSettings)
            {
                if (item.parameter == pair.Key)
                    item.LoadSlider(pair.Value);
            }
        }
    }

    public void SaveData(ref GameData _data)
    {
        _data.volumeSettings.Clear();
        foreach (UI_VolumeSlider item in volumeSettings)
        {
            _data.volumeSettings.Add(item.parameter, item.slider.value);
        }
    }
}
