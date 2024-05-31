using System.Collections.Generic;
using UnityEngine;

public class PhotoAlbumData : MonoBehaviour
{
    public static PhotoAlbumData Instance { get; private set; }

    private static string SaveKey = "MainSavePhotoAlbum";
    
    private List<Texture2D> _winterPhotos;
    private List<Texture2D> _springPhotos;
    private List<Texture2D> _summerPhotos;
    private List<Texture2D> _autumnPhotos;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Load();
        _winterPhotos.Clear();
        _springPhotos.Clear();
        _summerPhotos.Clear();
        _autumnPhotos.Clear();
        Save();
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

        _winterPhotos = data.winterPhotos;
        _springPhotos = data.springPhotos;
        _summerPhotos = data.summerPhotos;
        _autumnPhotos = data.autumnPhotos;
        
        Debug.Log("PhotoAlbum data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        Debug.Log("PhotoAlbum data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            winterPhotos = _winterPhotos,
            springPhotos = _springPhotos,
            summerPhotos = _summerPhotos,
            autumnPhotos = _autumnPhotos
        };

        return data;
    }

    #region SavePhotoMethods
    
    public void SaveNewWinterPhoto(Texture2D photo)
    {
        _winterPhotos.Add(photo);
        Save();
    }

    public void SaveNewSpringPhoto(Texture2D photo)
    {
        _springPhotos.Add(photo);
        Save();
    }

    public void SaveNewSummerPhoto(Texture2D photo)
    {
        _summerPhotos.Add(photo);
        Save();
    }

    public void SaveNewAutumnPhoto(Texture2D photo)
    {
        _autumnPhotos.Add(photo);
        Save();
    }
    
    #endregion

    #region GetIndexListMethods
    
    public List<int> GetWinterPhotoIndexList()
    {
        List<int> indexList = new List<int>();

        for (int i = 0; i < _winterPhotos.Count; i++)
        {
            indexList.Add(i);
        }

        return indexList;
    }

    public List<int> GetSpringPhotoIndexList()
    {
        List<int> indexList = new List<int>();

        for (int i = 0; i < _springPhotos.Count; i++)
        {
            indexList.Add(i);
        }

        return indexList;
    }

    public List<int> GetSummerPhotoIndexList()
    {
        List<int> indexList = new List<int>();

        for (int i = 0; i < _summerPhotos.Count; i++)
        {
            indexList.Add(i);
        }

        return indexList;
    }

    public List<int> GetAutumnPhotoIndexList()
    {
        List<int> indexList = new List<int>();

        for (int i = 0; i < _autumnPhotos.Count; i++)
        {
            indexList.Add(i);
        }

        return indexList;
    }
    
    #endregion

    #region GetPhotoMethods
    
    public Texture2D GetWinterPhoto(int index)
    {
        return _winterPhotos[index];
    }

    public Texture2D GetSpringPhoto(int index)
    {
        return _springPhotos[index];
    }

    public Texture2D GetSummerPhoto(int index)
    {
        return _summerPhotos[index];
    }

    public Texture2D GetAutumnPhoto(int index)
    {
        return _autumnPhotos[index];
    }

    #endregion
}
