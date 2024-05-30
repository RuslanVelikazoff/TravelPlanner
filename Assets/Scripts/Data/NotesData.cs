using System.Collections.Generic;
using UnityEngine;

public class NotesData : MonoBehaviour
{
    public static NotesData Instance { get; private set; }

    private const string SaveKey = "MainSaveNotes";

    private List<string> _textNotes;
    private List<GameData.NotesCategory> _categoryNotes;

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

    public void CreateNewNote(string notesText, GameData.NotesCategory notesNotesCategory)
    {
        _textNotes.Add(notesText);
        _categoryNotes.Add(notesNotesCategory);
        Save();
    }

    public string GetNotesText(int index)
    {
        return _textNotes[index];
    }

    public List<int> GetCategoryListIndex(GameData.NotesCategory notesCategory)
    {
        List<int> listIndex = new List<int>();

        for (int i = 0; i < _categoryNotes.Count; i++)
        {
            if (_categoryNotes[i] == notesCategory)
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
