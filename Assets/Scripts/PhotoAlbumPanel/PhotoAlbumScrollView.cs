using System.Collections.Generic;
using UnityEngine;

public class PhotoAlbumScrollView : MonoBehaviour
{
    [SerializeField]
    private GameObject photoPrefab;

    [SerializeField] 
    private Canvas canvas;

    private List<GameObject> photos = new List<GameObject>();
    private List<int> photoIndex;

    private GameData.PhotoCategory category;

    public void SpawnPrefabs(GameData.PhotoCategory selectedCategory)
    {
        category = selectedCategory;
        
        SetPhotoIndex();

        for (int i = 0; i < photoIndex.Count; i++)
        {
            var photo = Instantiate(photoPrefab, transform.position, Quaternion.identity);
            photo.transform.SetParent(canvas.transform);
            photo.transform.localScale = new Vector3(1, 1, 1);
            photo.transform.SetParent(this.gameObject.transform);
            photo.GetComponent<PhotoPrefab>().SpawnPrefab(photoIndex[i], category);
            photos.Add(photo);
        }
        
        Debug.Log(photoIndex.Count);
    }

    public void ResetPhotos()
    {
        if (photos != null)
        {
            for (int i = 0; i < photos.Count; i++)
            {
                Destroy(photos[i]);
                photos.RemoveAt(i);
                ResetPhotos();
            }
        }
    }

    private void SetPhotoIndex()
    {
        switch (category)
        {
            case GameData.PhotoCategory.Winter:
                photoIndex = PhotoAlbumData.Instance.GetWinterPhotoIndexList();
                break;
            case GameData.PhotoCategory.Spring:
                photoIndex = PhotoAlbumData.Instance.GetSpringPhotoIndexList();
                break;
            case GameData.PhotoCategory.Summer:
                photoIndex = PhotoAlbumData.Instance.GetSummerPhotoIndexList();
                break;
            case GameData.PhotoCategory.Autumn:
                photoIndex = PhotoAlbumData.Instance.GetAutumnPhotoIndexList();
                break;
        }
    }
}
