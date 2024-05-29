using System;
using System.Collections.Generic;
using UnityEngine;

public class TravelData : MonoBehaviour
{
    public static TravelData Instance { get; private set; }

    private const string SaveKey = "MainSaveTravel";
    
    private List<string> _city;
    private List<string> _places;
    private List<int> _budget;
    private List<DateTime> _date;
    private List<string> _dateString;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Load();
        SetStringToDate();
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

        _city = data.city;
        _places = data.places;
        _budget = data.budget;
        _date = data.date;
        _dateString = data.dateString;
        
        Debug.Log("Travel data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        Debug.Log("Travel data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            city = _city,
            places = _places,
            budget = _budget,
            date = _date,
            dateString = _dateString
        };

        return data;
    }

    #region StartMethods

    private void SetStringToDate()
    {
        for (int i = 0; i < _dateString.Count; i++)
        {
            if (DateTime.TryParse(_dateString[i], out DateTime result))
            {
                _date.Add(result);
            }
        }
    }

    #endregion


    #region GetMethods
    
    public string GetCityText(int index)
    {
        return _city[index];
    }

    public string GetPlacesText(int index)
    {
        return _places[index];
    }

    public int GetBudget(int index)
    {
        return _budget[index];
    }

    public DateTime GetDate(int index)
    {
        return _date[index];
    }

    public List<int> GetTravelsIndex()
    {
        List<int> listIndex = new List<int>();

        for (int i = 0; i < _city.Count; i++)
        {
            listIndex.Add(i);
        }

        return listIndex;
    }
    
    #endregion

    #region SetMethods

    public void SetCity(string city)
    {
        _city.Add(city);
    }

    public void SetPlaces(string places)
    {
        _places.Add(places);
    }

    public void SetBudget(int budget)
    {
        _budget.Add(budget);
    }

    public void SetDate(DateTime date)
    {
        _date.Add(date);
        _dateString.Add(date.ToString());
    }

    #endregion

    public void DeleteTravel(int index)
    {
        _city.RemoveAt(index);
        _places.RemoveAt(index);
        _budget.RemoveAt(index);
        _date.RemoveAt(index);
        _dateString.RemoveAt(index);
        Save();
    }
}
