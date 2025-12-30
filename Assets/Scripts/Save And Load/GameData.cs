using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int currency;

    public SerializableDictionary<string, bool> skillTree;
    public SerializableDictionary<string, int> inventory;
    public List<string> equipmentID;

    public SerializableDictionary<string, bool> checkpoints;
    public string closestCheckpointID;

    public float lostCurrencyX;
    public float lostCurrencyY;
    public int lostCurrencyAmount;

    public SerializableDictionary<string, float> volumeSettings;

    public GameData()
    {
        lostCurrencyX = 0;
        lostCurrencyY = 0;
        lostCurrencyAmount = 0;

        this.currency = 0;
        skillTree = new SerializableDictionary<string, bool>();
        inventory = new SerializableDictionary<string, int>();
        equipmentID = new List<string>();

        checkpoints = new SerializableDictionary<string, bool>();
        closestCheckpointID = string.Empty;

        volumeSettings = new SerializableDictionary<string, float>();
    }
}
