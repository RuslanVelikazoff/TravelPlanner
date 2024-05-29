using System.Collections.Generic;
using UnityEngine;

public class JournalData : MonoBehaviour
{
    public static JournalData Instance { get; private set; }

    private const string SaveKey = "MainSaveJournal";
    
    private List<string> _journalEntry;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);

        _journalEntry = data.journalEntry;
        
        Debug.Log("Journal data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Journal data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            journalEntry = _journalEntry
        };

        return data;
    }

    public void CreateJournalEntry(string journalEntry)
    {
        _journalEntry.Add(journalEntry);
        Save();
    }

    public string GetJournalEntryText(int index)
    {
        return _journalEntry[index];
    }

    public List<int> GetJournalEntryIndex()
    {
        List<int> indexList = new List<int>();

        for (int i = 0; i < _journalEntry.Count; i++)
        {
            indexList.Add(i);
        }

        return indexList;
    }

    public void DeleteJournalEntry(int index)
    {
        _journalEntry.RemoveAt(index);
    }
}
