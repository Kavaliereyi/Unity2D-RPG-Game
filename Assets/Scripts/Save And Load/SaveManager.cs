using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    [SerializeField] private string fileName;
    [SerializeField] private string filePath = "Kavaliere/kavaliere";
    [SerializeField] private bool encryptData;
    private GameData gameData;
    private List<ISaveManager> saveManagers;
    private FileDataHandler fileDataHandler;


    [ContextMenu("Delete saved file")]
    public void DeleteSavedData()
    {
        fileDataHandler = new FileDataHandler(filePath, fileName, encryptData);
        fileDataHandler.Delete();
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;

        fileDataHandler = new FileDataHandler(filePath, fileName, encryptData);
        saveManagers = FindAllSaveManagers();

        //LoadGame();

    }

    private void Start()
    {
        LoadGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = fileDataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No saved data found!");
            NewGame();
        }

        foreach (ISaveManager saveManager in saveManagers)
        {
            saveManager.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        Debug.Log("正在尝试保存游戏...");
        foreach (ISaveManager saveManager in saveManagers)
        {
            saveManager.SaveData(ref gameData);
        }
        fileDataHandler.Save(gameData);
    }

    private List<ISaveManager> FindAllSaveManagers()
    {
        IEnumerable<ISaveManager> saveManagers = FindObjectsOfType<MonoBehaviour>(true).OfType<ISaveManager>();

        return new List<ISaveManager>(saveManagers);
    }

    public bool HasSavedData()
    {
        if (fileDataHandler.Load() != null)
        {
            return true;
        }
        return false;
    }

}
