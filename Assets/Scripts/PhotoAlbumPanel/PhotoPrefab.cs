using UnityEngine;
using UnityEngine.UI;

public class PhotoPrefab : MonoBehaviour
{
    [SerializeField]
    private Image photoImage;

    private Texture2D photoTexture;
    private GameData.PhotoCategory category;

    public void SpawnPrefab(int index, GameData.PhotoCategory selectedCategory)
    {
        category = selectedCategory;
        SetTexture(index);
        Sprite sprite = Sprite.Create(photoTexture, new Rect(0,0,photoTexture.width, photoTexture.height),
            new Vector2(photoTexture.width / 2, photoTexture.height / 2));

        photoImage.sprite = sprite;
    }

    private void SetTexture(int index)
    {
        switch (category)
        {
            case GameData.PhotoCategory.Winter:
                photoTexture = PhotoAlbumData.Instance.GetWinterPhoto(index);
                break;
            case GameData.PhotoCategory.Spring:
                photoTexture = PhotoAlbumData.Instance.GetSpringPhoto(index);
                break;
            case GameData.PhotoCategory.Summer:
                photoTexture = PhotoAlbumData.Instance.GetSummerPhoto(index);
                break;
            case GameData.PhotoCategory.Autumn:
                photoTexture = PhotoAlbumData.Instance.GetAutumnPhoto(index);
                break;
        }
    }
}
