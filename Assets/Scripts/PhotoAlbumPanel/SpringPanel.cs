using UnityEngine;
using UnityEngine.UI;

public class SpringPanel : MonoBehaviour
{
    [SerializeField] 
    private PhotoAlbumScrollView scrollView;

    [SerializeField] 
    private Button newPhotoButton;

    private void OnEnable()
    {
        scrollView.ResetPhotos();
        scrollView.SpawnPrefabs(GameData.PhotoCategory.Spring);
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (newPhotoButton != null)
        {
            newPhotoButton.onClick.RemoveAllListeners();
            newPhotoButton.onClick.AddListener(() =>
            {
                AddNewPhoto(512);
                scrollView.ResetPhotos();
                scrollView.SpawnPrefabs(GameData.PhotoCategory.Spring);
            });
        }
    }

    private void AddNewPhoto( int maxSize )
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
        {
            Debug.Log( "Image path: " + path );
            if( path != null )
            {
                Texture2D texture = NativeGallery.LoadImageAtPath( path, maxSize );
                if( texture == null )
                {
                    Debug.Log( "Couldn't load texture from " + path );
                    return;
                }
                PhotoAlbumData.Instance.SaveNewSpringPhoto(texture);
            }
        } );
    }
}
