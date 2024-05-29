using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalPanel : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField journalEntryInputField;
    
    [SerializeField]
    private Button createNewJournalEntryButton;
    
    [SerializeField] 
    private JournalScrollView scrollView;

    private string journalEntryString;

    private void OnEnable()
    {
        scrollView.ResetJournalEntry();
        scrollView.SpawnPrefabs();
        
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (createNewJournalEntryButton != null)
        {
            createNewJournalEntryButton.onClick.RemoveAllListeners();
            createNewJournalEntryButton.onClick.AddListener(() =>
            {
                WriteJournalEntryToData();
            });
        }
    }

    private void WriteJournalEntryToData()
    {
        if (journalEntryInputField.text != string.Empty)
        {
            journalEntryString = journalEntryInputField.text;
            JournalData.Instance.CreateJournalEntry(journalEntryString);
            
            journalEntryString = string.Empty;
            journalEntryInputField.text = journalEntryString;
            
            scrollView.ResetJournalEntry();
            scrollView.SpawnPrefabs();
        }
    }
}
