using UnityEngine;
using UnityEngine.UI;

public class PhotoViewPanel : MonoBehaviour
{
    public static PhotoViewPanel Instance { get; private set; }

    [SerializeField]
    private Button backButton;

    [SerializeField] 
    private Image photoImage;

    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    public void OpenPanel(Sprite sprite, GameObject openPanel)
    {
        this.gameObject.SetActive(true);
        openPanel.SetActive(false);
        
        photoImage.sprite = sprite;

        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                openPanel.gameObject.SetActive(true);
            });
        }
    }
}
