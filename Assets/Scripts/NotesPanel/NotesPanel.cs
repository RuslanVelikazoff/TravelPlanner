using UnityEngine;
using UnityEngine.UI;

public class NotesPanel : MonoBehaviour
{
    private GameData.Category selectedCategory;

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
        selectedCategory = GameData.Category.Null;
        scrollView.ResetNotes();
        scrollView.SpawnPrefabs(GameData.Category.Shopping);
        scrollView.SpawnPrefabs(GameData.Category.Education);
        scrollView.SpawnPrefabs(GameData.Category.Travel);
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
                selectedCategory = GameData.Category.Shopping;
                scrollView.ResetNotes();
                scrollView.SpawnPrefabs(GameData.Category.Shopping);
                SetCategoryButtonSprites();
            });
        }

        if (educationButton != null)
        {
            educationButton.onClick.RemoveAllListeners();
            educationButton.onClick.AddListener(() =>
            {
                selectedCategory = GameData.Category.Education;
                scrollView.ResetNotes();
                scrollView.SpawnPrefabs(GameData.Category.Education);
                SetCategoryButtonSprites();
            });
        }

        if (travelButton != null)
        {
            travelButton.onClick.RemoveAllListeners();
            travelButton.onClick.AddListener(() =>
            {
                selectedCategory = GameData.Category.Travel;
                scrollView.ResetNotes();
                scrollView.SpawnPrefabs(GameData.Category.Travel);
                SetCategoryButtonSprites();
            });
        }
    }

    private void SetCategoryButtonSprites()
    {
        switch (selectedCategory)
        {
            case GameData.Category.Null:
                shoppingButton.GetComponent<Image>().sprite = shoppingInactiveSprite;
                educationButton.GetComponent<Image>().sprite = educationInactiveSprite;
                travelButton.GetComponent<Image>().sprite = travelInactiveSprite;
                break;
            case GameData.Category.Shopping:
                shoppingButton.GetComponent<Image>().sprite = shoppingActiveSprite;
                educationButton.GetComponent<Image>().sprite = educationInactiveSprite;
                travelButton.GetComponent<Image>().sprite = travelInactiveSprite;
                break;
            case GameData.Category.Education:
                shoppingButton.GetComponent<Image>().sprite = shoppingInactiveSprite;
                educationButton.GetComponent<Image>().sprite = educationActiveSprite;
                travelButton.GetComponent<Image>().sprite = travelInactiveSprite;
                break;
            case GameData.Category.Travel:
                shoppingButton.GetComponent<Image>().sprite = shoppingInactiveSprite;
                educationButton.GetComponent<Image>().sprite = educationInactiveSprite;
                travelButton.GetComponent<Image>().sprite = travelActiveSprite;
                break;
        }
    }
}
