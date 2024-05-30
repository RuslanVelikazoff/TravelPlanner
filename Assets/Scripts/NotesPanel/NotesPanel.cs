using UnityEngine;
using UnityEngine.UI;

public class NotesPanel : MonoBehaviour
{
    private GameData.NotesCategory _selectedNotesCategory;

    [SerializeField] 
    private Button addNotesButton;
    [SerializeField] 
    private GameObject addNotesPanel;
    
    [Space(13)]
    
    [SerializeField] 
    private Button shoppingButton;
    [SerializeField] 
    private Button educationButton;
    [SerializeField] 
    private Button travelButton;

    [Space(13)]
    
    [SerializeField]
    private Sprite shoppingActiveSprite;
    [SerializeField] 
    private Sprite shoppingInactiveSprite;
    [SerializeField] 
    private Sprite educationActiveSprite;
    [SerializeField] 
    private Sprite educationInactiveSprite;
    [SerializeField] 
    private Sprite travelActiveSprite;
    [SerializeField] 
    private Sprite travelInactiveSprite;

    [Space(13)]
    
    [SerializeField] 
    private NotesScrollView scrollView;

    private void OnEnable()
    {
        _selectedNotesCategory = GameData.NotesCategory.Null;
        scrollView.ResetNotes();
        scrollView.SpawnPrefabs(GameData.NotesCategory.Shopping);
        scrollView.SpawnPrefabs(GameData.NotesCategory.Education);
        scrollView.SpawnPrefabs(GameData.NotesCategory.Travel);
        SetCategoryButtonSprites();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (addNotesButton != null)
        {
            addNotesButton.onClick.RemoveAllListeners();
            addNotesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                addNotesPanel.SetActive(true);
            });
        }

        if (shoppingButton != null)
        {
            shoppingButton.onClick.RemoveAllListeners();
            shoppingButton.onClick.AddListener(() =>
            {
                _selectedNotesCategory = GameData.NotesCategory.Shopping;
                scrollView.ResetNotes();
                scrollView.SpawnPrefabs(GameData.NotesCategory.Shopping);
                SetCategoryButtonSprites();
            });
        }

        if (educationButton != null)
        {
            educationButton.onClick.RemoveAllListeners();
            educationButton.onClick.AddListener(() =>
            {
                _selectedNotesCategory = GameData.NotesCategory.Education;
                scrollView.ResetNotes();
                scrollView.SpawnPrefabs(GameData.NotesCategory.Education);
                SetCategoryButtonSprites();
            });
        }

        if (travelButton != null)
        {
            travelButton.onClick.RemoveAllListeners();
            travelButton.onClick.AddListener(() =>
            {
                _selectedNotesCategory = GameData.NotesCategory.Travel;
                scrollView.ResetNotes();
                scrollView.SpawnPrefabs(GameData.NotesCategory.Travel);
                SetCategoryButtonSprites();
            });
        }
    }

    private void SetCategoryButtonSprites()
    {
        switch (_selectedNotesCategory)
        {
            case GameData.NotesCategory.Null:
                shoppingButton.GetComponent<Image>().sprite = shoppingInactiveSprite;
                educationButton.GetComponent<Image>().sprite = educationInactiveSprite;
                travelButton.GetComponent<Image>().sprite = travelInactiveSprite;
                break;
            case GameData.NotesCategory.Shopping:
                shoppingButton.GetComponent<Image>().sprite = shoppingActiveSprite;
                educationButton.GetComponent<Image>().sprite = educationInactiveSprite;
                travelButton.GetComponent<Image>().sprite = travelInactiveSprite;
                break;
            case GameData.NotesCategory.Education:
                shoppingButton.GetComponent<Image>().sprite = shoppingInactiveSprite;
                educationButton.GetComponent<Image>().sprite = educationActiveSprite;
                travelButton.GetComponent<Image>().sprite = travelInactiveSprite;
                break;
            case GameData.NotesCategory.Travel:
                shoppingButton.GetComponent<Image>().sprite = shoppingInactiveSprite;
                educationButton.GetComponent<Image>().sprite = educationInactiveSprite;
                travelButton.GetComponent<Image>().sprite = travelActiveSprite;
                break;
        }
    }
}
