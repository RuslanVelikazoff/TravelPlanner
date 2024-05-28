using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotesPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI notesText;
    
    [SerializeField] 
    private Button deleteNotesButton;

    private int notesIndex;

    public void SpawnNotesPrefab(int index)
    {
        notesIndex = index;
        
        SetNotesText();
        ButtonClickAction();
    }

    private void SetNotesText()
    {
        notesText.text = NotesData.Instance.GetNotesText(notesIndex);
    }

    private void ButtonClickAction()
    {
        if (deleteNotesButton != null)
        {
            deleteNotesButton.onClick.RemoveAllListeners();
            deleteNotesButton.onClick.AddListener(() =>
            {
                NotesData.Instance.DeleteNotes(notesIndex);
                Destroy(this.gameObject);
            });
        }
    }
}
