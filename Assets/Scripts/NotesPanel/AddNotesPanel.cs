using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddNotesPanel : MonoBehaviour
{
    [SerializeField] 
    private Button okButton;
    [SerializeField]
    private GameObject notesPanel;
    
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
    private TMP_InputField notesInputField;

    private GameData.NotesCategory _selectedNotesCategory;

    private void OnEnable()
    {
        notesInputField.text = String.Empty;
        _selectedNotesCategory = GameData.NotesCategory.Null;
        SetCategoryButtonSprites();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (okButton != null)
        {
            okButton.onClick.RemoveAllListeners();
            okButton.onClick.AddListener(() =>
            {
                if (CreateNewNotes())
                {
                    this.gameObject.SetActive(false);
                    notesPanel.SetActive(true);
                }
            });
        }

        if (shoppingButton != null)
        {
            shoppingButton.onClick.RemoveAllListeners();
            shoppingButton.onClick.AddListener(() =>
            {
                _selectedNotesCategory = GameData.NotesCategory.Shopping;
                SetCategoryButtonSprites();
            });
        }

        if (educationButton != null)
        {
            educationButton.onClick.RemoveAllListeners();
            educationButton.onClick.AddListener(() =>
            {
                _selectedNotesCategory = GameData.NotesCategory.Education;
                SetCategoryButtonSprites();
            });
        }

        if (travelButton != null)
        {
            travelButton.onClick.RemoveAllListeners();
            travelButton.onClick.AddListener(() =>
            {
                _selectedNotesCategory = GameData.NotesCategory.Travel;
                SetCategoryButtonSprites();
            });
        }
    }

    private bool CreateNewNotes()
    {
        if (notesInputField.text != string.Empty && _selectedNotesCategory != GameData.NotesCategory.Null)
        {
            NotesData.Instance.CreateNewNote(notesInputField.text, _selectedNotesCategory);
            return true;
        }
        else
        {
            return false;
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
