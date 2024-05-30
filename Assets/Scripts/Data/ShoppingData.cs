using System.Collections.Generic;
using UnityEngine;

public class ShoppingData : MonoBehaviour
{
    public static ShoppingData Instance { get; private set; }

    private const string SaveKey = "MainSaveShopping";

    private List<GameData.ShoppingCategory> _categoryPurchase;
    private List<string> _purchaseName;
    private List<bool> _completedPurchase;

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

        _categoryPurchase = data.categoryShopping;
        _purchaseName = data.purchaseName;
        _completedPurchase = data.completedPurchase;
        
        Debug.Log("Shopping data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Shopping data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            categoryShopping = _categoryPurchase,
            purchaseName = _purchaseName,
            completedPurchase = _completedPurchase
        };

        return data;
    }
    
    public bool IsCompletedPurchase(int index)
    {
        return _completedPurchase[index];
    }

    public void ChangeCompletePurchase(int index, bool completed)
    {
        _completedPurchase[index] = completed;
        Save();
    }

    #region GetMethods
    
    public string GetPurchaseText(int index)
    {
        return _purchaseName[index];
    }

    public List<int> GetPurchasesIndexList(GameData.ShoppingCategory category)
    {
        List<int> index = new List<int>();

        for (int i = 0; i < _categoryPurchase.Count; i++)
        {
            if (category == GameData.ShoppingCategory.Null)
            {
                index.Add(i);
            }

            else if (_categoryPurchase[i] == category)
            {
                index.Add(i);
            }
        }

        return index;
    }
    
    #endregion

    public void CreatePurchase(string name, GameData.ShoppingCategory category)
    {
        _purchaseName.Add(name);
        _categoryPurchase.Add(category);
        _completedPurchase.Add(false);
        Save();
    }

    public void DeletePurchase(int index)
    {
        _purchaseName.RemoveAt(index);
        _categoryPurchase.RemoveAt(index);
        _completedPurchase.RemoveAt(index);
        Save();
    }
}
