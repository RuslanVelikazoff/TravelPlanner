using UnityEngine;
using UnityEngine.UI;

public class PhotoAlbumPanel : MonoBehaviour
{
    [SerializeField] 
    private Button winterButton;
    [SerializeField] 
    private Button springButton;
    [SerializeField] 
    private Button summerButton;
    [SerializeField] 
    private Button autumnButton;

    [Space(13)]
    
    [SerializeField]
    private GameObject winterPanel;
    [SerializeField] 
    private GameObject springPanel;
    [SerializeField] 
    private GameObject summerPanel;
    [SerializeField] 
    private GameObject autumnPanel;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (winterButton != null)
        {
            winterButton.onClick.RemoveAllListeners();
            winterButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                winterPanel.SetActive(true);
            });
        }

        if (springButton != null)
        {
            springButton.onClick.RemoveAllListeners();
            springButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                springPanel.SetActive(true);
            });
        }

        if (summerButton != null)
        {
            summerButton.onClick.RemoveAllListeners();
            summerButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                summerPanel.SetActive(true);
            });
        }

        if (autumnButton != null)
        {
            autumnButton.onClick.RemoveAllListeners();
            autumnButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                autumnPanel.SetActive(true);
            });
        }
    }
}
