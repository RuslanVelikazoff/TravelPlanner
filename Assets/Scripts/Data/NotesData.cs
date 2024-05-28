using System.Collections.Generic;
using UnityEngine;

public class NotesData : MonoBehaviour
{
    public static NotesData Instance { get; private set; }

    private const string SaveKey = "MainSaveNotes";

    public List<string> _textNotes;
    public List<GameData.Category> _categoryNotes;

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

        _textNotes = data.textNotes;
        _categoryNotes = data.categoryNotes;
        
        Debug.Log("Notes data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Notes data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            textNotes = _textNotes,
            categoryNotes = _categoryNotes
        };

        return data;
    }

    public void CreateNewNote(string notesText, GameData.Category notesCategory)
    {
        _textNotes.Add(notesText);
        _categoryNotes.Add(notesCategory);
        Save();
    }

    public string GetNotesText(int index)
    {
        return _textNotes[index];
    }

    public List<int> GetCategoryListIndex(GameData.Category category)
    {
        List<int> listIndex = new List<int>();

        for (int i = 0; i < _categoryNotes.Count; i++)
        {
            if (_categoryNotes[i] == category)
            {
                listIndex.Add(i);
            }
        }

        return listIndex;
    }

    public void DeleteNotes(int index)
    {
        _textNotes.RemoveAt(index);
        _categoryNotes.RemoveAt(index);
        Save();
    }
}
