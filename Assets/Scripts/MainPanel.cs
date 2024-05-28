using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] 
    private Button journalButton;
    [SerializeField] 
    private Button shoppingButton;
    [SerializeField] 
    private Button notesButton;
    [SerializeField] 
    private Button travelButton;
    [SerializeField] 
    private Button remindersButton;
    [SerializeField] 
    private Button photoAlbumButton;

    [Space(13)]

    [SerializeField] 
    private GameObject journalPanel;
    [SerializeField] 
    private GameObject shoppingPanel;
    [SerializeField] 
    private GameObject notesPanel;
    [SerializeField] 
    private GameObject travelPanel;
    [SerializeField] 
    private GameObject remindersPanel;
    [SerializeField] 
    private GameObject photoAlbumPanel;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (journalButton != null)
        {
            journalButton.onClick.RemoveAllListeners();
            journalButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                journalPanel.SetActive(true);
            });
        }

        if (shoppingButton != null)
        {
            shoppingButton.onClick.RemoveAllListeners();
            shoppingButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                shoppingPanel.SetActive(true);
            });
        }

        if (notesButton != null)
        {
            notesButton.onClick.RemoveAllListeners();
            notesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                notesPanel.SetActive(true);
            });
        }

        if (travelButton != null)
        {
            travelButton.onClick.RemoveAllListeners();
            travelButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                travelPanel.SetActive(true);
            });
        }

        if (remindersButton != null)
        {
            remindersButton.onClick.RemoveAllListeners();
            remindersButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                remindersPanel.SetActive(true);
            });
        }

        if (photoAlbumButton != null)
        {
            photoAlbumButton.onClick.RemoveAllListeners();
            photoAlbumButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                photoAlbumPanel.SetActive(true);
            });
        }
    }
}
