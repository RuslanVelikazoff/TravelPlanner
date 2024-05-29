using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalEntryPrefab : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI journalEntryText;

    [SerializeField]
    private Button deleteJournalEntryButton;

    private int journalEntryIndex;

    public void SpawnJournalEntryPrefab(int index)
    {
        journalEntryIndex = index;
        
        SetJournalEntryText();
        ButtonClickAction();
    }

    private void SetJournalEntryText()
    {
        journalEntryText.text = JournalData.Instance.GetJournalEntryText(journalEntryIndex);
    }

    private void ButtonClickAction()
    {
        if (deleteJournalEntryButton != null)
        {
            deleteJournalEntryButton.onClick.RemoveAllListeners();
            deleteJournalEntryButton.onClick.AddListener(() =>
            {
                JournalData.Instance.DeleteJournalEntry(journalEntryIndex);
                Destroy(this.gameObject);
            });
        }
    }
}
