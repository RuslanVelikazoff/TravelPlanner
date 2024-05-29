using System;
using System.Collections.Generic;
using UnityEngine;

public class RemindersData : MonoBehaviour
{
    public static RemindersData Instance { get; private set; }

    private const string SaveKey = "MainSaveReminders";

    private List<string> _reminderTexts;
    private List<DateTime> _reminderDates;
    private List<string> _reminderDatesString;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Load();
        SetStringToDate();
        CheckValidReminderDate();
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

        _reminderTexts = data.reminderTexts;
        _reminderDates = data.reminderDates;
        _reminderDatesString = data.reminderDatesString;
        
        Debug.Log("Reminders data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Reminders data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            reminderTexts = _reminderTexts,
            reminderDates = _reminderDates,
            reminderDatesString = _reminderDatesString
        };

        return data;
    }

    #region Startmethods

    private void SetStringToDate()
    {
        for (int i = 0; i < _reminderDatesString.Count; i++)
        {
            if (DateTime.TryParse(_reminderDatesString[i], out DateTime result))
            {
                _reminderDates.Add(result);
            }
        }
    }

    private void CheckValidReminderDate()
    {
        for (int i = 0; i < _reminderDates.Count; i++)
        {
            if (_reminderDates[i] < DateTime.Now)
            {
                _reminderTexts.RemoveAt(i);
                _reminderDates.RemoveAt(i);
                _reminderDatesString.RemoveAt(i);
                CheckValidReminderDate();
                break;
            }
        }
    }

    #endregion

    #region GetMethods

    public List<int> GetRemindersIndexList()
    {
        List<int> indexList = new List<int>();

        for (int i = 0; i < _reminderTexts.Count; i++)
        {
            indexList.Add(i);
        }

        return indexList;
    }

    public string GetReminderText(int index)
    {
        return _reminderTexts[index];
    }

    #endregion

    #region SetMethods

    public void SetReminderText(string reminderText)
    {
        _reminderTexts.Add(reminderText);
    }

    public void SetReminderDate(DateTime date)
    {
        _reminderDates.Add(date);
        _reminderDatesString.Add(date.ToString());
    }

    #endregion
}
